﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicle2
{
    internal class StaticConstructor
    {
        static public string Division;
        public int Id;
        static StaticConstructor() //static StaticConstructor(int i) not allowed because staic constructor not take any arguments
        {
            Division = "Csp";
            
            Console.WriteLine($"value of  division is in static constuctor {Division}\n");
        }
        public StaticConstructor(int Sid)
        {
         
            
            Id = Sid;
            
            Console.WriteLine($"value of  ID is in public constructor {Id}\n");
        }
    }
}
