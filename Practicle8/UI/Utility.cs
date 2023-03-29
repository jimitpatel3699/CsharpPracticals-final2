using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicle8.UI
{
    internal static class Utility
    {
        public static string GetUserInput(string prompt) {
            Console.WriteLine($"Enter {prompt}");
            return Console.ReadLine();
        }
        internal static void PressEnter()
        {
            Console.WriteLine("Press Enter to Continue...\n");
            Console.ReadLine();
        }

        public static void PrintMessage(string msg,bool success=true)
        {
            if(success)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(msg);
            Console.ForegroundColor=ConsoleColor.White;
            PressEnter();

        }
    }
}
