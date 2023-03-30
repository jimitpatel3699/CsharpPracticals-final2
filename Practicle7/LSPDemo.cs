using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicle7
{
    //create one interface IFood which is parent for all available classes and which is ensure derived class replace it.
    interface IFood
    {
        string FoodType();
        string FoodIngrients();
        string FoodOrigin();
        
    }
    internal class Pitza : IFood
    {
        public string FoodType()
        {
            return "fastfood";
        }

        public string FoodIngrients()
        {
            return "pitzabase,cheese,sauce...";
        }

        public string FoodOrigin()
        {
            return "itely";
        }
    }


    internal class PavBhaji : IFood
    {
        public string FoodIngrients()
        {
            return "pav,bhaji,butter...";
        }

        public string FoodOrigin()
        {
            return "india";
        }

        public string FoodType()
        {
            return "fastfood";
        }
    }

    internal class PaniPuri : IFood
    {
        public string FoodIngrients()
        {
            return "patato,puri,beans,water...";
        }

        public string FoodOrigin()
        {
            return "india";
        }

        public string FoodType()
        {
            return "fastfood";
        }
    }

   
}
