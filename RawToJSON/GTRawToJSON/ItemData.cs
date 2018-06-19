using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using GTRawToJSON.Recipes;

namespace GTRawToJSON
{
    public class ItemData
    {
        //Core Data
        public int Id;
        public string ItemName;
        public int Rarity;
        public string Properties;
        public string Category;
        public string BaseColor;
        public string OverlayColor;
        public int Hardness;
        public int GrowTimeSeconds;
        public string ClothingType;

        public string Description;
        public string Chi;

        public PetBattleAbility PetBattleAbility;
        public StoreItem StoreItem;

        public List<string> MysteryPinataRecipes;
        public List<string> BurningRecipes;
        public SplicingRecipe SplicingRecipe;
        public CrystalRecipe CrystalRecipe;
        public LabRecipe LabRecipe;
        public SewingRecipe SewingRecipe;
        public ForgingRecipe ForgingRecipe;
    }

    public class StoreItem
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyType Type;

        public int Price;
        public string Info;

        public StoreItem(CurrencyType type, int price, string extraInfo = null)
        {
            this.Type = type;
            this.Price = price;
            this.Info = extraInfo;
        }

        public enum CurrencyType
        {
            Gems,
            Growtokens
        }
    }

    public class PetBattleAbility
    {
        public string Element;
        public string AbilityName;
        public string AbilityDescription;
        public int Cooldown;
        public string Prefix;
        public string Suffix;

        public PetBattleAbility(string Name, string Desc, string Prefix, string Suffix, string Element, int cooldown = 0)
        {
            this.AbilityName = Name;
            this.AbilityDescription = Desc;
            this.Prefix = Prefix;
            this.Suffix = Suffix;
            this.Element = Element;
            this.Cooldown = cooldown;
        }
    }

}
