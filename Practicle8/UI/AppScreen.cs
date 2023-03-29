using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicle8.UI
{
    public static class AppScreen
    {
            internal static void Welcome()
            {
                Console.Clear();
                //set title of console.
                Console.Title = "ATM APP";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------WELCOME---------------------------------------------");
                Console.WriteLine("\n----------------------------:SIMFORM BANK ATM:---------------------------------------");
                  
            }
            

    }
}
