using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicle2
{
    internal class ImplicitConstuctor
    {
        //implicit constructor 
        int Number;
        string Name;

        public void PrintData()
        {
            Console.WriteLine($"Name value set by implicit contructor is {Name}\n");
            Console.WriteLine($"Number value set by implicit contructor is {Number} \n");
        }

    }
}
