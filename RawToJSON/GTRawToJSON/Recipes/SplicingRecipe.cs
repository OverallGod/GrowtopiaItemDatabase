using System;
using System.Collections.Generic;
using System.Text;

namespace GTRawToJSON.Recipes
{
    public class SplicingRecipe
    {
        public string SpliceItem1;
        public string SpliceItem2;

        public SplicingRecipe(string item1, string item2)
        {
            this.SpliceItem1 = item1;
            this.SpliceItem2 = item2;
        }
    }
}
