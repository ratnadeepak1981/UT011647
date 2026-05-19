using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleBankApplication
{
   
    public class BankAccount
    {
        public string AccountHolder {  get; set; }
        public static string AccountNumber { get; set; }

        private decimal AccountBalance;

        private readonly List<Transaction> Transactions;

        public BankAccount(string Holder,string Number,decimal OpeningBalance )
        {
            AccountHolder=Holder;
            AccountNumber=Number;
            AccountBalance=OpeningBalance;

            Transactions = new List<Transaction>();
            Transactions.Add(new Transaction(DateTime.Now, "Opening", OpeningBalance, AccountBalance));

        }
        public void AccountDetails()
        {
            Console.WriteLine($"Account Holder : {AccountHolder}");
            Console.WriteLine($"Account Number : {AccountNumber}");
        }

        internal void BalanceEnquiry()
        {
            Console.WriteLine($"Current Balance for the Account {AccountNumber}: {AccountBalance.ToString("F2")}");
        }
        internal decimal GetAccountBalance()
        {
            return AccountBalance;
        }

        internal bool Deposit(decimal DepositAmount)
        {
            if (DepositAmount >= 0)
            {
                AccountBalance += DepositAmount;
                Transactions.Add(new Transaction(DateTime.Now, "Deposit", DepositAmount, AccountBalance));
              // Console.WriteLine($"Deposit successful Updated balance : {AccountBalance}");
                return true;
               
            }
            else
            {
                // Console.WriteLine("Deposit Amount should be greater than zero");
                throw new InvalidAmountException("Deposit Amount should be greater than zero");
                return false;
            }
        }

        internal bool Withdrawal(decimal WithdrawalAmount)
        {
            if (WithdrawalAmount > 0)
            {
                if (AccountBalance >= WithdrawalAmount)
                {
                    AccountBalance -= WithdrawalAmount;
                    Transactions.Add(new Transaction(DateTime.Now, "Withdrawal", WithdrawalAmount, AccountBalance));
                   // Console.WriteLine($"Withdrawal Successful Updated balance : {AccountBalance}");
                    return true;
                }
                else
                {
                    throw new InsufficientFundException("Insufficient balance" , GetAccountBalance());
                    return false;
                }
            }
            else
            {
                throw new InvalidAmountException("Withdrawal Amount should be greater than zero");
                //Console.WriteLine("Withdrawal Amount should be greater than zero");
                return false;
            }
        }
        internal List<Transaction>  GetTransactionDetails()
        {
            return Transactions;
        }
    }
}
