using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicle2
{
    internal class ParametrisedConstrctor
    {
        private string Id;
        public string Name,Bdate;
        protected decimal Mobile;

        
        protected internal ParametrisedConstrctor(string Sid, string Sname, string SbDate, decimal Smobile)
        {
            Id = Sid;
            Name = Sname;
            Bdate = SbDate;
            Mobile=Smobile;
        }

        public void PrintData()
        {
            Console.WriteLine($"ID value set by parametrised contructor is {Id}\n");
            Console.WriteLine($"Name value set by parametrised contructor is {Name}\n");
            Console.WriteLine($"Bdate value set by parametrised contructor is {Bdate}\n");
            Console.WriteLine($"Mobile value set by parametrised contructor is {Mobile} \n");
        }


    }
}
