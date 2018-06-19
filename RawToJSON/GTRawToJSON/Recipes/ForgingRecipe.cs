using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTRawToJSON.Recipes
{
    public class ForgingRecipe
    {
        public string material;
        public int count;
        public string additionalItem;

        public ForgingRecipe(string material, int count = 100, string additionalItem = "")
        {
            this.material = material;
            this.count = count;
            this.additionalItem = additionalItem;
        }
    }
}
