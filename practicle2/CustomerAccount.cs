using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace practicle2
{
    internal class CustomerAccount
    {
        readonly string BankName;
        string CustomerName;
        long CustomerAccountNo;
        public CustomerAccount(string CustName,long CustAccNo)
        {
            BankName = "DCB BANK";
            CustomerAccountNo = CustAccNo;
            CustomerName = CustName;
        }

        //printInfo() method declare for display the passbook of user.
        //method not take any parameter also not have returntype.
            public void PrintInfo()
        {
            Console.WriteLine("=======================");
            Console.WriteLine($"WELCOME TO {BankName}");
            Console.WriteLine("=======================");
            Console.WriteLine("=======Pass-Book=========\n");
                
            Console.WriteLine($"Customer Name: {CustomerName}\n");
            Console.WriteLine($"AccountNo: {CustomerAccountNo}\n");
            
            Console.WriteLine("=========================");
        }
    }
}
