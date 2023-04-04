using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Practicle8.UI
{
    internal static class Utility
    {
        private static long tranID;
        private static CultureInfo culture = new CultureInfo("hi-IN"); 

        public static long GetTransactionID()
        {
            return ++tranID;
        }
        public static string GetSecretInput(string prompt)
        {
            bool isPrompt = true;
            string asterics = "";

            StringBuilder input = new StringBuilder();

            while (true)
            {
                if(isPrompt)
                {
                    Console.WriteLine(prompt);
                }
                isPrompt=false;
                ConsoleKeyInfo inputKey =Console.ReadKey(true);

                if(inputKey.Key == ConsoleKey.Enter)
                {
                    if(input.Length==4)
                    {
                        break;
                    }
                    else
                    {
                        PrintMessage("Please enter 4 digit long card number only.", false);
                        isPrompt = true;
                        input.Clear();
                        continue;
                    }
                }
                if (inputKey.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                }else if(inputKey.Key != ConsoleKey.Backspace)
                {
                    input.Append(inputKey.KeyChar);
                    Console.Write(asterics + "*");
                }
            }
            return input.ToString();
        }


        public static string GetUserInput(string prompt) {
            Console.WriteLine($"Enter {prompt}");
            return Console.ReadLine();
        }

        public static void PrintDotAnimation(int timer =10)
        {
            
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);

            }
            Console.Clear();
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
            Console.WriteLine("\n"+msg);
            Console.ForegroundColor=ConsoleColor.White;
            PressEnter();

        }

        public static string FormatAmout(decimal amt)
        {
            
            return String.Format(culture, "{0:#,#}", amt);
        }
    }
}
