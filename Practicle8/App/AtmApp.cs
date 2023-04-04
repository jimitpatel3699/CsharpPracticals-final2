using ConsoleTables;
using Practicle8.Domain.Entities;
using Practicle8.Domain.Enums;
using Practicle8.Domain.Interfaces;
using Practicle8.UI;


namespace Practicle8
{
    internal class AtmApp : IUserLogin,IUserAccountActions,ITransaction
    {
        private List<UserAccount> userAccountsList;
        private UserAccount selectedAccount;
        private List<Transaction> _listofTransactionsl;
        private const decimal minimumKeptAmount = 500;
        private readonly AppScreen screen;

        public AtmApp()
        {
            screen = new AppScreen();
        }

        public void Run()
        {
            AppScreen.Welcome();
            CheckUserCardNumAndPassword();
            AppScreen.WelcomeCustomer(selectedAccount.FullName);
            while(true)
            {
                AppScreen.DisplayAppMenu();
                ProcessMenuoption();
            }
            
        }
        public void InitializeData()
        {
            userAccountsList = new List<UserAccount>
            {
                new UserAccount{Id=1,FullName="jimit patel",AccountNumber=123456,CardNumber=321321,CardPin=3699,AccountBalance=5000.00m,IsLocked=false },
                new UserAccount{Id=2,FullName="saurabh mishra",AccountNumber=654321,CardNumber=123123,CardPin=3699,AccountBalance=50000.00m,IsLocked=false },
                new UserAccount{Id=3,FullName="jagu patel",AccountNumber=901692,CardNumber=789987,CardPin=3699,AccountBalance=50000.00m,IsLocked=false },
            };

            _listofTransactionsl = new List<Transaction>();
        }

        public void CheckUserCardNumAndPassword()
        {
            bool isCorrectLogin = false;
            while (isCorrectLogin == false)
            {
                UserAccount inputAccount = AppScreen.UserLoginform();
                AppScreen.LoginProgress();

                foreach (UserAccount account in userAccountsList)
                {
                    selectedAccount = account;
                    if (inputAccount.CardNumber.Equals(selectedAccount.CardNumber))
                    {
                        selectedAccount.TotalLogin++;
                        if (inputAccount.CardPin.Equals(selectedAccount.CardPin))
                        {
                            selectedAccount = account;

                            if (selectedAccount.IsLocked || selectedAccount.TotalLogin > 3)
                            {
                                //print a lock message
                                AppScreen.PrintLockScreen();
                            }
                            else
                            {
                                selectedAccount.TotalLogin = 0;
                                isCorrectLogin = true;
                                break;
                            }
                        }
                        if (isCorrectLogin == false)
                        {
                            Utility.PrintMessage("\n Invalid card number or PIN.", false);
                            selectedAccount.IsLocked = selectedAccount.TotalLogin == 3;
                            if (selectedAccount.IsLocked)
                            {
                                AppScreen.PrintLockScreen();
                            }
                        }
                        Console.Clear();
                    }
                }

            }
        }


        private void ProcessMenuoption()
        {
            switch(Validator.Convert<int>("an option:"))
            {
                case (int)AppMenu.CheckBalance:
                    {
                        CheckBalance();
                        break;
                    }
                case (int)AppMenu.Placedeposite:
                    {
                        PlaceDeposite();
                        break;
                    }
                case (int)AppMenu.MakeWithdrawal:
                    {
                        MakeWithDrawal();
                        break;
                    }
                case (int)AppMenu.InternalTransfer:
                    {
                        var interTransfer = screen.InternalTransferForm();
                        ProcessInternalTransfer(interTransfer);
                        break;
                    }   
                case (int)AppMenu.ViewTransaction:
                    {
                        ViewTransaction();
                        break;
                    }
                case (int)AppMenu.Logout:
                    {
                        AppScreen.LogoutProgress();
                        Utility.PrintMessage("You have successfully logged out. Please collect your ATM card.");
                        Run();
                        break;
                    }
                default:
                    {
                        Utility.PrintMessage("Invalid Option", false);
                        break;
                    }
            }
        }

        public void CheckBalance()
        {
            Utility.PrintMessage($"Your account balance is :{Utility.FormatAmout(selectedAccount.AccountBalance)}");
        }

        public void PlaceDeposite()
        {
            Console.WriteLine($"\nOnly multiple of 100 and 500 Rs. notes allowed.\n");
            var TransactionAmt = Validator.Convert<int>($"amount {AppScreen.cur}");

            //counting
            Console.WriteLine("\nChecking and Counting notes.");
            Utility.PrintDotAnimation();
            Console.WriteLine("");

            if(TransactionAmt<=0)
            {
                Utility.PrintMessage("Amount needs to be greater than zero. Try again.", false);
                return;
            }
            if(TransactionAmt%100!=0) {
            
                Utility.PrintMessage($"Enter deposite amount in multiple of 100 or 500. Try again",false);
                    return;
            }
            if(PreviewBanknotesCount(TransactionAmt)==false)
            {
                Utility.PrintMessage($"You have cancelled your action",false);
                return;
            }
            InsertTransaction(selectedAccount.Id, TransactionType.Deposit, TransactionAmt, "");


            //update account balance

            selectedAccount.AccountBalance += TransactionAmt;

            //print success message

            Utility.PrintMessage($"Your deposite of {Utility.FormatAmout(TransactionAmt)} wa succesful",true);
        }

        public void MakeWithDrawal()
        {
            var transactionAmt = 0;
            int selectedAmount = AppScreen.SelectAmount();
            
            if(selectedAmount!=0)
            {
                transactionAmt= selectedAmount;
            }
            //else
            //{
            //    transactionAmt = Validator.Convert<int>($"amount {AppScreen.cur}");
            //}

            //input validation
            if(transactionAmt<=0)
            {
                Utility.PrintMessage("Amount needs to be greter than zero.", false);
                return;
            }else if(transactionAmt%100!=0)
            {
                Utility.PrintMessage("Amount needs to be multiply of 100 or 500.", false);
                return;
            }

            //business logic validation
            if(transactionAmt>selectedAccount.AccountBalance)
            {
                Utility.PrintMessage("Withdrawl fail due to low balance.", false);
                return;
            }
            if(selectedAccount.AccountBalance-transactionAmt<minimumKeptAmount)
            {
                Utility.PrintMessage($"Withdrawal failed. your account needs to have miminum {Utility.FormatAmout(minimumKeptAmount)}");
                return;
            }
            //bind withdrawls details to transaction object
            InsertTransaction(selectedAccount.Id, TransactionType.Withdrawal, -transactionAmt, "");
            //update account balance
            selectedAccount.AccountBalance -= transactionAmt;
            //success message
            Utility.PrintMessage($"You have successfully withdrawl {Utility.FormatAmout(transactionAmt)}", true);

        
        }

        private bool PreviewBanknotesCount(int amount)
        {
            int fiveHundredNotesCount = amount / 500;
            int oneHundredNotescount = (amount % 500) / 100;

            Console.WriteLine("\nSummary");
            Console.WriteLine("---------");
            Console.WriteLine($"{AppScreen.cur}500 X {fiveHundredNotesCount}");
            Console.WriteLine($"{AppScreen.cur}100 X {oneHundredNotescount}");
            Console.WriteLine($"Total amount: {Utility.FormatAmout(amount)}\n\n");

            int opt = Validator.Convert<int>("1 to Confirm");
            return opt.Equals(1);

        }

        public void InsertTransaction(long _UserBankAccountId, TransactionType _tranType, decimal _tranAmount, string _desc)
        {
            //create new transaction object
            var transaction = new Transaction()
            {
                TransactionId = Utility.GetTransactionID(),
                UserBankAccountId= _UserBankAccountId,
                TransactionDate= DateTime.Now,
                TransactionType= _tranType,
                TransactionAmount= _tranAmount,
                Description= _desc

            };

            //add transaction object to thr list
            _listofTransactionsl.Add(transaction);
        }

        public void ViewTransaction()
        {
           var filteredTransactionList = _listofTransactionsl.Where(t=>t.UserBankAccountId==selectedAccount.Id).ToList();
            //check if data available or not
            if(filteredTransactionList.Count <= 0 )
            {
                Utility.PrintMessage($"No transaction found", true);
            }
            else
            {
                var table = new ConsoleTable("Id", "Transaction Date", "Type", "Descriptions", "Amount" + AppScreen.cur);
                foreach(var tran in filteredTransactionList)
                {
                    table.AddRow(tran.TransactionId, tran.TransactionDate, tran.TransactionType, tran.Description, tran.TransactionAmount);
                }
                table.Options.EnableCount = false;
                table.Write();
                Utility.PrintMessage($"You have {filteredTransactionList.Count} transaction", true);
            }
        }

        private void ProcessInternalTransfer(InternalTransfer internalTransfer)
        {
            if( internalTransfer.TransferAmount<=0 ) 
            {
                Utility.PrintMessage("Amount needs to be more than zero.", false);
                return;
            }
            //check sender account balance
            if(internalTransfer.TransferAmount>selectedAccount.AccountBalance ) 
            {
                Utility.PrintMessage("Balance insufficints to transfer. transfer failed", false);
                return;
            }

            //check the minimum kept amount
            if((selectedAccount.AccountBalance-internalTransfer.TransferAmount)<minimumKeptAmount)
            {
                Utility.PrintMessage("Transfer failed due to minimum maitain balance ", false);
                return;
            }

            //check receiver acount number is valid
            UserAccount ReceiverAccountNum = new UserAccount();
            foreach(var account in userAccountsList)
            {
                if(account.AccountNumber == internalTransfer.ReciepeintAccNum)
                {
                    ReceiverAccountNum.AccountNumber= account.AccountNumber;
                }        
            }
            if (ReceiverAccountNum.AccountNumber == 0)
            {
                Utility.PrintMessage("transfer failed due to receiver account number invalid ", false);
                return;
            }
            else {
                //add transaction at sender side
                InsertTransaction(selectedAccount.Id, TransactionType.Transfer, -internalTransfer.TransferAmount, $"{internalTransfer.ReciepeintAccNum}");
                //update balance of sender
                selectedAccount.AccountBalance -= internalTransfer.TransferAmount;

                //add transaction record at receiver side
                InsertTransaction(ReceiverAccountNum.Id, TransactionType.Transfer, internalTransfer.TransferAmount, $"{selectedAccount.AccountNumber}");

                //update balance of receiver
                ReceiverAccountNum.AccountBalance += internalTransfer.TransferAmount;
                
            }
            }
    }
}