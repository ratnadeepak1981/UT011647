using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleBankApplication
{
    internal class ConsoleMenu
    {
        private string AccountHolder = "P RATNADEEPAK";
        private string AccountNumber = "123-234567-010";
        private decimal OpeningBalance = 0m;
        private int Choice;
        private string BankName = "ABC Banking Coperation";
        private BankAccount bankAccount;

        public void Run()
        {
            WelcomeMessage();
            CreateAccount();
            MainMenu();
        }


        public void WelcomeMessage()
        {
            Console.WriteLine($"{new String('*', Console.WindowWidth)}");
            Console.WriteLine($"**{new String(' ', Console.WindowWidth-4)}**");
            Console.WriteLine($"**{BankName.PadLeft(Console.WindowWidth/2)} {new String(' ', (Console.WindowWidth/2)-5)}**");
            Console.WriteLine($"**{new String(' ', Console.WindowWidth - 4)}**");
            Console.WriteLine($"{new String('*', Console.WindowWidth)}");
        }
        private void CreateAccount()
        {
            string Username;
            do
            {
                //  loop until the valid name is entered
                Console.Write("Enter your name : ");
                Username = Console.ReadLine();
                int username;
                if (string.IsNullOrWhiteSpace(Username) )
                {
                    Console.WriteLine("Name cannot be blank!");
                }
                else if (!Username.All(char.IsLetter))
                {
                    Console.WriteLine("Invalid Name! Name should contain only Letters");
                }
                else if (!int.TryParse(Username, out username))
                {
                    Console.WriteLine($"Hello {Username} Welcome to {BankName}");
                    break;
                }
               
            } while (true);


            Console.ReadKey();
            do
            {
                Console.Write("Enter Opening balance : ");
               
                // TryParse returns true if the input is a valid decimal and assigns it to OperningBalance
                if (decimal.TryParse(Console.ReadLine(), out OpeningBalance))
                {
                    if (OpeningBalance <= 0)
                    {
                        Console.WriteLine("Open Balance cannot Negative or Zero");
                    }
                    else
                    {
                        break; // Exit the loop when the input is valid
                    }
                }

                Console.WriteLine("Invalid amount. Please enter a valid decimal amount.\n");

            } while (true);
           
            bankAccount = new BankAccount(AccountHolder, AccountNumber, OpeningBalance);

            Console.WriteLine($"Account Holder : {AccountHolder}  Account Number : {AccountNumber} Current Balance :{OpeningBalance}\n");
                 
            Console.WriteLine($"Account Holder : {AccountHolder}");
            Console.WriteLine($"Account Number : {AccountNumber}");
         
            Console.WriteLine($"Current Balance :{OpeningBalance.ToString("F2")}");

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();

        }
         
        public void MenuDetails()
        {

            Console.WriteLine($"{new String('*', Console.WindowWidth)}");
            Console.WriteLine($"**{new String(' ', Console.WindowWidth - 4)}**");
            string MainMenu="Main Menu";
            Console.WriteLine($"**{MainMenu.PadLeft(Console.WindowWidth / 2)} {new String(' ', (Console.WindowWidth / 2) - 5)}**");
            //Console.WriteLine(" Main Menu:");
            Console.WriteLine($"**{new String(' ', Console.WindowWidth - 4)}**");
            Console.WriteLine($"{new String('*', Console.WindowWidth)}");
            Console.WriteLine(new String(' ', (Console.WindowWidth / 2) - 15)+"1. View Account Details");
            Console.WriteLine(new String(' ', (Console.WindowWidth / 2) - 15)+"2. Check Balance");
            Console.WriteLine(new String(' ', (Console.WindowWidth / 2) - 15)+"3. Deposit Funds");
            Console.WriteLine(new String(' ', (Console.WindowWidth / 2) - 15)+"4. Withdraw Funds");
            Console.WriteLine(new String(' ', (Console.WindowWidth / 2) - 15)+"5. Transaction History");
            Console.WriteLine(new String(' ', (Console.WindowWidth / 2) - 15)+"6. Exit");
           

            do
            {
                try
                {
                    Console.Write(new String(' ', (Console.WindowWidth / 2) - 15) + "Enter your choice (1-6) > ");

                    // TryParse returns true if the input is a valid decimal and assigns it to OperningBalance
                    if (int.TryParse(Console.ReadLine(), out Choice))
                    {
                        break; // Exit the loop when the input is valid
                    }

                    Console.WriteLine("Invalid Choice. Please enter a valid choice (1-6).\n");

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            } while (true);
        }

        public void MainMenu()
        {

            do
            {
                try
                {
                    Console.Clear();
                    WelcomeMessage();
                    MenuDetails();
                    switch (Choice)
                    {
                        case 1:
                            bankAccount.AccountDetails();
                            break;
                        case 2:
                            bankAccount.BalanceEnquiry();
                            break;
                        case 3:
                            decimal DepositAmount;
                            do
                            {
                                Console.Write("Enter the deposit amount : ");
                                // TryParse returns true if the input is a valid amount and assigns it to deposit amount
                                if (decimal.TryParse(Console.ReadLine(), out DepositAmount))
                                {
                                    break; // Exit the loop when the input is valid
                                }

                                Console.WriteLine("Invalid amount. Please enter a valid deposit amount.\n");

                            } while (true);
                            if (bankAccount.Deposit(DepositAmount))
                            {
                                Console.WriteLine($"Deposit successful Updated balance : {bankAccount.GetAccountBalance()}");
                            }
                            break;

                        case 4:
                            decimal WithdrawalAmount;
                            do
                            {
                                Console.Write("Enter the withdrawal amount : ");
                                // TryParse returns true if the input is a valid amount and assigns it to deposit amount
                                if (decimal.TryParse(Console.ReadLine(), out WithdrawalAmount))
                                {
                                    break; // Exit the loop when the input is valid
                                }

                                Console.WriteLine("Invalid amount. Please enter a valid deposit amount.\n");

                            } while (true);

                            if(bankAccount.Withdrawal(WithdrawalAmount))
                            {
                                 Console.WriteLine($"Withdrawal Successful Updated balance : {bankAccount.GetAccountBalance()}");
                            }
                            break;
                        case 5:
                            TransactionHistory();
                            break;
                        case 6:
                            Console.Write("   Thank you for using Console Bank Application ");
                            Choice = 6; // Exit the menu loop
                            break;

                        default:
                            Console.WriteLine("Invalid Choice. Please enter a valid choice (1-6).\n");
                            break;
                    }
                    Console.Write("Press any key to return to the menu...");
                    Console.ReadKey();
                }
                catch (InsufficientFundException  ifex)
                {
                    Console.WriteLine($"{ifex.Message} Avilable only  {ifex.Balance} ");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Console.ReadKey();
                }
            } while (Choice!=6);

        }
        
        void TransactionHistory()
        {
            List<Transaction> transactions = bankAccount.GetTransactionDetails();
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }
            else
            {
                Console.WriteLine($"\nTransaction History  {transactions.Count}  Records\n");
                Console.WriteLine(new string('=', 72));
                Console.Write("| No".PadRight(10));
                Console.Write("Date and Time".PadRight(23));
                Console.Write("Description".PadRight(17));
                Console.Write("Amount".PadRight(10));
                Console.Write("Balance".PadRight(11)+"|");
                Console.WriteLine($"\n{new string('=', 72)}");

                // foreach uses  LINQ Select Method to fetch data , index in the List collection
               
                 foreach (var (transactionRow , index) in transactions.Select((value, row) => (value, row)))
                {
                    decimal Amount = 0;
                    if (transactionRow.Type == "Withdrawal")
                    {
                        Amount = transactionRow.Amount * -1;
                    }
                    else
                    {
                        Amount = transactionRow.Amount ;
                    }
                            Console.WriteLine($"| {(index + 1).ToString().PadRight(1)} | " +
                            $" {transactionRow.TransactionDate.ToString("dd MMM yyyy HH:mm").PadRight(25)} |" +
                            $" {transactionRow.Type.PadRight(10)}| {Amount.ToString("F2").PadLeft(10)} |" +
                            $" {transactionRow.CurrentBalance.ToString("F2").PadLeft(10)} |");
                            Console.WriteLine(new string('-', 71));
                }

                /*
                 
                   In standard for loop 
                =====================================
                Transaction transaction;

                for (int No = 0; No < transactions.Count; No++)
                {
                    transaction = transactions[No];
                    decimal Amount = 0;
                    if (transaction.Type == "Withdrawal")
                    {
                        Amount = transaction.Amount * -1;
                    }
                    else
                    {
                        Amount = transaction.Amount;
                    }
                    Console.WriteLine($"| {(No + 1).ToString().PadRight(1)} | " +
                        $" {transaction.TransactionDate.ToString("dd MMM yyyy HH:mm").PadRight(25)} |" +
                        $" {transaction.Type.PadRight(10)}| {Amount.ToString("F2").PadLeft(10)} |" +
                        $" {transaction.CurrentBalance.ToString("F2").PadLeft(10)} |");
                    Console.WriteLine(new string('-', 71));
                }
               */

                Console.WriteLine(new string('-', 55));
                Console.WriteLine("Current Balance  for Account "+ BankAccount.AccountNumber+ "   " + bankAccount.GetAccountBalance().ToString("F2"));
                Console.WriteLine(new string('-', 55));
               
            }
        }
    } 
}
