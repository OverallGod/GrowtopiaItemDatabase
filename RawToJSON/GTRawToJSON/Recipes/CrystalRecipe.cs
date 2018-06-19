using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GTRawToJSON.Recipes
{
    public class CrystalRecipe
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CrystalType one;
        [JsonConverter(typeof(StringEnumConverter))]
        public CrystalType two;
        [JsonConverter(typeof(StringEnumConverter))]
        public CrystalType three;
        [JsonConverter(typeof(StringEnumConverter))]
        public CrystalType four;
        [JsonConverter(typeof(StringEnumConverter))]
        public CrystalType five;
        public int gives;

        public CrystalRecipe(CrystalType one, CrystalType two, CrystalType three, CrystalType four, CrystalType five, int gives = 1)
        {
            this.one = one;
            this.two = two;
            this.three = three;
            this.four = four;
            this.five = five;
            this.gives = gives;
        }

        public static CrystalType StringToCrystal(string src)
        {
            switch (src)
            {
                case "R": return CrystalType.Red;
                case "G": return CrystalType.Green;
                case "B": return CrystalType.Blue;
                case "W": return CrystalType.White;
                case "K": return CrystalType.Black;
                default: return CrystalType.Green;
            }
        }

        public enum CrystalType
        {
            Red,
            Green,
            Blue,
            White,
            Black
        }
    }
}
