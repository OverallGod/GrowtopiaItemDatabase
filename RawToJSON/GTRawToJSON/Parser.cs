using System;
using System.Collections.Generic;
using System.IO;


using GTRawToJSON.Recipes;

using static GTRawToJSON.Recipes.CrystalRecipe;
using static GTRawToJSON.Recipes.SewingRecipe;

namespace GTRawToJSON
{
    public class Parser
    {
        private static Dictionary<int, ItemData> items = new Dictionary<int, ItemData>();
        public static Dictionary<int, ItemData> ParseFiles()
        {
            AddCore();

            AddDescriptions();
            AddChi();
            AddPetBattleAbilities();
            AddStoreItems();
            AddSplicingRecipes();
            AddMPinataRecipes();
            AddBurningRecipes();
            AddCrystalRecipes();
            AddLabRecipes();
            AddSewingRecipes();
            AddForgingRecipes();
            return items;
        }

        private static void AddCore()
        {
            int i = 0;
            Console.WriteLine("Parsing core data...");
            foreach (var j in File.ReadAllLines(Path.Combine("GrowtopiaItemDatabase", "CoreData.txt")))
            {
                if (String.IsNullOrEmpty(j) || j.StartsWith("//")) continue;
                string[] str = j.Split('|');
                int id = Convert.ToInt32(str[0]);
                items[id] = new ItemData();
                items[id].Id = id;
                items[id].ItemName = str[1];
                items[id].Rarity = Convert.ToInt32(str[2]);
                items[id].Properties = str[3];
                items[id].Category = str[4];
                items[id].BaseColor = str[5];
                items[id].OverlayColor = str[6];
                items[id].Hardness = Convert.ToInt32(str[7]);
                items[id].GrowTimeSeconds = Convert.ToInt32(str[8]);
                items[id].ClothingType = str[9];
            }
        }

        private static void AddDescriptions()
        {
            int i = 0;
            Console.WriteLine("Parsing descriptions...");
            foreach (var j in File.ReadAllLines(Path.Combine("GrowtopiaItemDatabase", "Data", "Descriptions.txt")))
            {
                if (String.IsNullOrEmpty(j) || j.StartsWith("//")) continue;
                string[] str = j.Split('|');
                int id = Convert.ToInt32(str[0]);
                items[id].Description = str[1];
            }
        }

        private static void AddChi()
        {
            Console.WriteLine("Parsing chi list...");
            foreach (var j in File.ReadAllLines(Path.Combine("GrowtopiaItemDatabase", "Data", "ChiList.txt")))
            {
                if (String.IsNullOrEmpty(j) || j.StartsWith("//")) continue;

                string[] str = j.Split('|');
                int id = Convert.ToInt32(str[0]);
                string chi = str[1];
                items[id].Chi = chi;
            }
        }

        private static void AddPetBattleAbilities()
        {
            Console.WriteLine("Parsing pet battle abilities...");
            foreach (var j in File.ReadAllLines(Path.Combine("GrowtopiaItemDatabase", "Data", "PetBattleAbilities.txt")))
            {
                if (String.IsNullOrEmpty(j) || j.StartsWith("//")) continue;

                string[] str = j.Split('|');
                int id = Convert.ToInt32(str[0]);
                string chi = str[1];
                string ability = str[2];
                string desc = str[3];
                int cooldown = Convert.ToInt32(str[4]);
                string prefix = str[5];
                string suffix = str[6];
                items[id].PetBattleAbility = new PetBattleAbility(ability, desc, prefix, suffix, chi, cooldown);
            }
        }

        private static void AddStoreItems()
        {
            foreach (var j in File.ReadAllLines(Path.Combine("GrowtopiaItemDatabase", "Data", "StoreItems.txt")))
            {
                if (String.IsNullOrEmpty(j) || j.StartsWith("//")) continue;

                string[] str = j.Split('|');
                if (String.Equals(str[1], "STORE"))
                {
                    int id = Convert.ToInt32(str[0]);
                    int price = Convert.ToInt32(str[3]);

                    if (String.Equals(str[2], "GEM"))
                    {
                        items[id].StoreItem = new StoreItem(StoreItem.CurrencyType.Gems, price);
                    }
                    else if (String.Equals(str[2], "TOKEN"))
                    {
                        items[id].StoreItem = new StoreItem(StoreItem.CurrencyType.Growtokens, price);
                    }
                    if (str.Length > 4) items[id].StoreItem.Info = str[4];
                }
            }
        }

        private static void AddSplicingRecipes()
        {
            Console.WriteLine("Parsing splicable list...");
            foreach (var j in File.ReadAllLines(Path.Combine("GrowtopiaItemDatabase", "RecipeData", "Splicables.txt")))
            {
                if (String.IsNullOrEmpty(j) || j.StartsWith("//")) continue;

                string[] str = j.Split('|');
                int produced = Convert.ToInt32(str[0]);
                int seed1 = Convert.ToInt32(str[1]);
                int seed2 = Convert.ToInt32(str[2]);
                items[produced].SplicingRecipe = new SplicingRecipe(items[seed1].ItemName, items[seed2].ItemName);

                //Multi fruit items
                if (str.Length == 4)
                {
                    int itemsWithSameRecipe = Convert.ToInt32(str[3]);
                    for (var i = produced + 2; i < itemsWithSameRecipe; i += 2)
                    {
                        items[produced].SplicingRecipe = new SplicingRecipe(items[seed1].ItemName, items[seed2].ItemName);
                    }
                }
            }
        }

        private static void AddMPinataRecipes()
        {
            foreach (var j in File.ReadAllLines(Path.Combine("GrowtopiaItemDatabase", "RecipeData", "MysteryPinataRecipes.txt")))
            {
                if (String.IsNullOrEmpty(j) || j.StartsWith("//")) continue;

                string[] str = j.Split('|');
                if (String.Equals(str[1], "MPINATA"))
                {
                    int id = Convert.ToInt32(str[0]);
                    List<string> mPinataRecipes = new List<string>();

                    for (int i = 2; i < str.Length; i++)
                    {
                        mPinataRecipes.Add(items[Convert.ToInt32(str[i])].ItemName);
                    }
                    items[id].MysteryPinataRecipes = mPinataRecipes;
                }
            }
        }

        private static void AddBurningRecipes()
        {
            foreach (var j in File.ReadAllLines(Path.Combine("GrowtopiaItemDatabase", "RecipeData", "BurningRecipes.txt")))
            {
                if (String.IsNullOrEmpty(j) || j.StartsWith("//")) continue;

                string[] str = j.Split('|');
                if (String.Equals(str[1], "BURN"))
                {
                    int id = Convert.ToInt32(str[0]);
                    List<string> burningRecipes = new List<string>();

                    for (int i = 2; i < str.Length; i++)
                    {
                        burningRecipes.Add(items[Convert.ToInt32(str[i])].ItemName);
                    }
                    items[id].BurningRecipes = burningRecipes;
                }
            }
        }

        private static void AddCrystalRecipes()
        {
            foreach (var j in File.ReadAllLines(Path.Combine("GrowtopiaItemDatabase", "RecipeData", "CrystalRecipes.txt")))
            {
                if (String.IsNullOrEmpty(j) || j.StartsWith("//")) continue;

                string[] str = j.Split('|');
                if (String.Equals(str[1], "CRYSTAL"))
                {
                    int id = Convert.ToInt32(str[0]);
                    CrystalType one = CrystalRecipe.StringToCrystal(str[2]);
                    CrystalType two = CrystalRecipe.StringToCrystal(str[3]);
                    CrystalType three = CrystalRecipe.StringToCrystal(str[4]);
                    CrystalType four = CrystalRecipe.StringToCrystal(str[5]);
                    CrystalType five = CrystalRecipe.StringToCrystal(str[6]);

                    if (str.Length > 7)
                    {
                        int gives = Convert.ToInt32(str[7]);
                        items[id].CrystalRecipe = new CrystalRecipe(one, two, three, four, five, gives);
                    }
                    else
                    {
                        items[id].CrystalRecipe = new CrystalRecipe(one, two, three, four, five);
                    }
                }
            }
        }

        private static void AddLabRecipes()
        {
            foreach (var j in File.ReadAllLines(Path.Combine("GrowtopiaItemDatabase", "RecipeData", "LabRecipes.txt")))
            {
                if (String.IsNullOrEmpty(j) || j.StartsWith("//")) continue;

                string[] str = j.Split('|');
                if (String.Equals(str[1], "MIX"))
                {
                    int id = Convert.ToInt32(str[0]);
                    int item1 = Convert.ToInt32(str[2]);
                    int count1 = Convert.ToInt32(str[3]);
                    int item2 = Convert.ToInt32(str[4]);
                    int count2 = Convert.ToInt32(str[5]);
                    int item3 = Convert.ToInt32(str[6]);
                    int count3 = Convert.ToInt32(str[7]);

                    if (str.Length > 8)
                    {
                        items[id].LabRecipe = new LabRecipe(items[item1].ItemName, count1, items[item2].ItemName, count2, items[item3].ItemName, count3, Convert.ToInt32(str[8]));
                    }
                    else
                    {
                        items[id].LabRecipe = new LabRecipe(items[item1].ItemName, count1, items[item2].ItemName, count2, items[item3].ItemName, count3);
                    }
                }
            }
        }

        private static void AddSewingRecipes()
        {
            foreach (var j in File.ReadAllLines(Path.Combine("GrowtopiaItemDatabase", "RecipeData", "SewingRecipes.txt")))
            {
                if (String.IsNullOrEmpty(j) || j.StartsWith("//")) continue;

                string[] str = j.Split('|');
                if (String.Equals(str[1], "SEW"))
                {
                    int id = Convert.ToInt32(str[0]);
                    Bolt one = SewingRecipe.StringToBolt(str[2]);
                    Bolt two = SewingRecipe.StringToBolt(str[3]);
                    Stitch three = SewingRecipe.StringToStitch(str[4]);
                    Bolt four = SewingRecipe.StringToBolt(str[5]);
                    Stitch five = SewingRecipe.StringToStitch(str[6]);
                    items[id].SewingRecipe = new SewingRecipe(one, two, three, four, five);
                }
            }
        }

        private static void AddForgingRecipes()
        {
            foreach (var j in File.ReadAllLines(Path.Combine("GrowtopiaItemDatabase", "RecipeData", "ForgingRecipes.txt")))
            {
                if (String.IsNullOrEmpty(j) || j.StartsWith("//")) continue;

                string[] str = j.Split('|');
                if (String.Equals(str[1], "FORGE"))
                {
                    int id = Convert.ToInt32(str[0]);
                    int material = Convert.ToInt32(str[2]);

                    if (str.Length > 3)
                    {
                        int count = Convert.ToInt32(str[3]);
                        int special = Convert.ToInt32(str[4]);
                        items[id].ForgingRecipe = new ForgingRecipe(items[material].ItemName, count, items[special].ItemName);
                    }
                    else
                    {
                        items[id].ForgingRecipe = new ForgingRecipe(items[material].ItemName);
                    }
                }
            }
        }
    }
}
