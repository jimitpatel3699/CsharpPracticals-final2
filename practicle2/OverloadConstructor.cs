using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicle2
{
    internal class OverloadConstructor
    {
        
        public OverloadConstructor(string Fname , string Lname) {

            Console.WriteLine($"Welcome,{Fname} {Lname}\n");
       
        }

        internal OverloadConstructor(int Num1, int Num2) {

            Console.WriteLine($"Sum of {Num1} and {Num2} is {Num1 + Num2}\n");
        
        }
        protected internal OverloadConstructor(int Num1, int Num2, int Num3)
        {

            Console.WriteLine($"Sum of {Num1},{Num2} and {Num3} is {Num1 + Num2 + Num3}\n");

        }
    }
}
