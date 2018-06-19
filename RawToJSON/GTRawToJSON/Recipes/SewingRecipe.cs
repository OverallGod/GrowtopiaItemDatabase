using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace GTRawToJSON.Recipes
{
    public class SewingRecipe
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Bolt item1;

        [JsonConverter(typeof(StringEnumConverter))]
        public Bolt item2;
        [JsonConverter(typeof(StringEnumConverter))]
        public Stitch firstStitch;

        [JsonConverter(typeof(StringEnumConverter))]
        public Bolt item3;

        [JsonConverter(typeof(StringEnumConverter))]
        public Stitch secondStitch;

        public SewingRecipe(Bolt one, Bolt two, Stitch stitch, Bolt three, Stitch stitch2)
        {
            this.item1 = one;

            this.item2 = two;
            this.firstStitch = stitch;


            this.item3 = three;
            this.secondStitch = stitch2;

        }

        public static Stitch StringToStitch(String src)
        {
            switch (src)
            {
                case "Straight": return Stitch.Straight;
                case "Zigzag": return Stitch.Zigzag;
                case "Overcast": return Stitch.Overcasting;
                case "Locking": return Stitch.Locking;
                case "Triple": return Stitch.TripleStretch;
                case "Saddle": return Stitch.Saddle;
                case "Blind": return Stitch.Blind;
                default: return Stitch.Straight;
            }
        }

        public static Bolt StringToBolt(String src)
        {
            switch (src)
            {
                case "Red": return Bolt.Red;
                case "Green": return Bolt.Green;
                case "Blue": return Bolt.Blue;

                case "Grey": return Bolt.Grey;
                case "White": return Bolt.White;
                case "Black": return Bolt.Black;

                case "Purple": return Bolt.Purple;
                case "Yellow": return Bolt.Yellow;
                case "Aqua": return Bolt.Aqua;

                case "Floral": return Bolt.Floral;
                case "Wool": return Bolt.Wool;
                default: return Bolt.Red;
            }
        }

        private string StitchToString(Stitch type)
        {
            switch (type)
            {
                case Stitch.Straight:
                    return "Straight Stitch";
                case Stitch.Zigzag:
                    return "Zigzag Stitch";
                case Stitch.Overcasting:
                    return "Overcasting Stitch";
                case Stitch.Locking:
                    return "Locking Stitch";
                case Stitch.TripleStretch:
                    return "Triple Stretch Stitch";
                case Stitch.Saddle:
                    return "Saddle Stitch";
                case Stitch.Blind:
                    return "Blind Stitch";
                default:
                    return "?";
            }
        }
        public enum Bolt
        {
            Red,
            Green,
            Blue,
            Black,
            White,
            Grey,
            Yellow,
            Purple,
            Aqua,
            Wool,
            Floral
        }

        public enum Stitch
        {
            Straight,
            Zigzag,
            Overcasting,
            Locking,
            TripleStretch,
            Saddle,
            Blind
        }
    }
}
