using System;
using System.Collections.Generic;
using System.Text;

namespace GTRawToJSON.Recipes
{
    public class LabRecipe
    {
        public string item1;
        public int item1Count;

        public string item2;
        public int item2Count;

        public string item3;
        public int item3Count;

        public int gives;

        public LabRecipe(string one, int oneCount, string two, int twoCount, string three, int threeCount, int gives = 1)
        {
            this.item1 = one;
            this.item1Count = oneCount;

            this.item2 = two;
            this.item2Count = twoCount;

            this.item3 = three;
            this.item3Count = threeCount;
            this.gives = gives;
        }
    }
}
