using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using GTRawToJSON.Recipes;

using static GTRawToJSON.Recipes.CrystalRecipe;
using static GTRawToJSON.Recipes.SewingRecipe;

using Newtonsoft.Json;

namespace GTRawToJSON
{
    class Program
    {

        static void Main(string[] args)
        {
            if (!File.Exists(Path.Combine("GrowtopiaItemDatabase", "CoreData.txt")))
            {
                Console.WriteLine("Could not find the core data file. Make sure the Growtopia Database folder is next to the executable.");
                Console.ReadKey();
                return;
            }

            var items = Parser.ParseFiles();
            Console.WriteLine("Done, making the json file...");
            MakeJson(items);
            Console.WriteLine("Done, saved as database.json. Press any key to exit");
            Console.ReadKey();
        }

        static void MakeJson(Dictionary<int, ItemData> items)
        {
            File.WriteAllText("database.json", JsonConvert.SerializeObject(items, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }));
        }
    }
}
