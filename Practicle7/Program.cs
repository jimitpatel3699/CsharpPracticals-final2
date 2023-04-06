namespace Practicle7
{
    internal class Program
    {
        enum Options
        {
            SRP = 1,
            OCP,
            LSP,
            ISP,
            DIP
        }
        static void Main(string[] args)
        {
            int Choice, Amount;
            double Discount = 0;
            string UserName = null;
            string Password = null;
            string Bdate = null;
            string Gender=null;
            double? Mobile=null;
            ValidateData validatedata = new ValidateData();
            while (true)
            {
                Console.WriteLine("\n===========");
                Console.WriteLine("1.SRP demo");
                Console.WriteLine("2.OCP demo");
                Console.WriteLine("3.LSP demo");
                Console.WriteLine("4.ISP demo");
                Console.WriteLine("5.DIP demo");
                Console.WriteLine("===========");
                Console.Write("Enter your Choice:");
                Choice=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("===========");
                Options ch = (Options)Choice;               
                switch (ch)
                {
                    case Options.SRP:
                        {
                            Console.Write("\nEnter username:");
                            UserName= Console.ReadLine();
                            Console.Write("\nEnter password:");
                            Password= Console.ReadLine();
                            if(validatedata.ValidateInfo(UserName, Password))
                            {
                                Console.WriteLine("Login sucess");
                            }
                            else
                            {
                                Console.WriteLine("Login failed");
                            }
                            break;
                        }
                    case Options.OCP:
                        {
                            Console.WriteLine("Enter Amount of Invoice:");
                            Amount= Convert.ToInt32(Console.ReadLine());
                            if(Amount<10000)
                            {
                                FinalInvoice finalInvoice = new FinalInvoice();
                                Discount = finalInvoice.GetInvoiceDiscount(Amount);
                                Console.WriteLine($"final discount = {Amount-Discount}");                                
                            }else if(Amount>=10000)
                            {
                                ProposedInvoice proposedInvoice = new ProposedInvoice();
                                Discount= proposedInvoice.GetInvoiceDiscount(Amount);
                                Console.WriteLine($"final discount = {Amount-Discount}");
                            }
                            Console.WriteLine($"final Amount Paid:{Discount}");
                            break;
                        }
                    case Options.LSP:
                        {                            
                            IFood food = new Pitza();
                            Console.WriteLine("\n-------------------------------------------------------------------------");
                            Console.WriteLine("IFood food = new pitza();");
                            Console.WriteLine($"pitza class ingredients method food.FoodIngrients();:-> {food.FoodIngrients()}");
                            Console.WriteLine($"pitza class origin method food.FoodOrigin();:->{food.FoodOrigin()}");
                            Console.WriteLine($"pitza class food type method food.FoodType();:->{food.FoodType()}");                                                        
                            food = new PavBhaji();
                            Console.WriteLine("-------------------------------------------------------------------------");
                            Console.WriteLine($"\nfood = new PavBhaji(); ");
                            Console.WriteLine($"PavBhaji class ingredients method food.FoodIngrients();:-> {food.FoodIngrients()}");
                            Console.WriteLine($"PavBhaji class origin method food.FoodOrigin();:->{food.FoodOrigin()}");
                            Console.WriteLine($"PavBhaji class food type method food.FoodType();:->{food.FoodType()}");                                                        
                            food = new PaniPuri();
                            Console.WriteLine("-------------------------------------------------------------------------");
                            Console.WriteLine($"\nfood = new panipuri(); ");
                            Console.WriteLine($"PaniPuri class ingredients method food.FoodIngrients();:-> {food.FoodIngrients()}");
                            Console.WriteLine($"PaniPuri class origin method food.FoodOrigin();:->{food.FoodOrigin()}");
                            Console.WriteLine($"PaniPuri class food type method food.FoodType();:->{food.FoodType()}");
                            break;
                        }
                    case Options.ISP:
                        {
                            //Using HPLaserJetPrinter we can access all Printer Services
                            Console.WriteLine("\n-------------------------------------------------------------------------");
                            Console.WriteLine("HPLaserJetPrinter implemets all interfaces.");
                            HPLaserJetPrinter hPLaserJetPrinter = new HPLaserJetPrinter();
                            hPLaserJetPrinter.Print("Printing");
                            hPLaserJetPrinter.Scan("Scanning");
                            hPLaserJetPrinter.Fax("Faxing");
                            hPLaserJetPrinter.PrintDuplex("PrintDuplex");
                            //Using LiquidInkjetPrinter we can only Access Print and Scan Printer Services
                            Console.WriteLine("\n-------------------------------------------------------------------------");
                            Console.WriteLine("LiquidInkjetPrinter implements only Access Print and Scan Printer interface.");
                            LiquidInkjetPrinter liquidInkjetPrinter = new LiquidInkjetPrinter();
                            liquidInkjetPrinter.Print("Printing");
                            liquidInkjetPrinter.Scan("Scanning");
                            break;
                        }
                    case Options.DIP:
                        {                            
                            Student student = new Student(RepositoryFactory.GetStudentRepository());
                            student.Save();
                            break;
                        }
                }
            }            
        }
    }
}