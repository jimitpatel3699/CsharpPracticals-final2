using Practicle8.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicle8.UI
{
    public  class AppScreen
    {
        internal const string cur = "Rs. ";
            internal static void Welcome()
            {
                Console.Clear();
                //set title of console.
                Console.Title = "ATM APP";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------WELCOME---------------------------------------------");
                Console.WriteLine("\n----------------------------:SIMFORM BANK ATM:---------------------------------------");
                  
            }

        internal static UserAccount UserLoginform()
        {
            UserAccount tempUserAccount = new UserAccount();

            tempUserAccount.CardNumber = Validator.Convert<long>("your card number.");
            tempUserAccount.CardPin = Convert.ToInt32(Utility.GetSecretInput("Enter your card PIN"));
            return tempUserAccount;
        }

        internal static void LoginProgress()
        {
            Console.WriteLine("\nChecking card number and PIN...");
            Utility.PrintDotAnimation();
        }

        internal static void PrintLockScreen()
        {
            Console.Clear();
            Utility.PrintMessage("Your account is locked. Please contact Branch for unlock account. Thank You!", true);
            Utility.PressEnter();
            Environment.Exit(1);
        }
        public static void WelcomeCustomer(string fullname)
        {
            Console.WriteLine($"Welcome back,{fullname}");
            Utility.PressEnter();
        }

        internal static void DisplayAppMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------WELCOME---------------------------------------------");
            Console.WriteLine("\n----------------------------:SIMFORM BANK ATM:---------------------------------------");
            Console.WriteLine(":                                                                                     :");
            Console.WriteLine("1. Account Balance               :");
            Console.WriteLine("2. Cash Deposite                 :");
            Console.WriteLine("3. Withdrawl                     :");
            Console.WriteLine("4. Transfer                      :");
            Console.WriteLine("5. Transactions                  :");
            Console.WriteLine("6. Logout                        :");

        }
        
        internal static void LogoutProgress()
        {
            Console.WriteLine("Thank you for using atm.");
            Utility.PrintDotAnimation();
            Console.Clear();
        }

        internal static int SelectAmount()
        {

            Console.WriteLine("");

            int selectedAmount = Validator.Convert<int>("Enter Amount to Withdrawl:");
            return selectedAmount;
            //if(selectedAmount%100!=0)
            //{
            //    Utility.PrintMessage("Please enter amount multiply to 100 or 500", false);
            //    SelectAmount();
            //    return -1;
            //}
            //else
            //{
            //    return selectedAmount;
            //}
        }

        internal InternalTransfer InternalTransferForm()
        {
            var InternalTransfer = new InternalTransfer();
            InternalTransfer.ReciepeintAccNum = Validator.Convert<long>("recipient account number:");
            InternalTransfer.TransferAmount = Validator.Convert<decimal>($"amount {cur} ");
            InternalTransfer.ReciepeintName = Utility.GetUserInput("recipints name:");
            return InternalTransfer;
        }
    
    }
}
