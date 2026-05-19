using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleBankApplication
{
    internal class Transaction
    {
        public string Type { get; }
        public decimal Amount { get; }
        public decimal CurrentBalance { get; }
        public DateTime TransactionDate { get; }

        public Transaction(DateTime date, string type, decimal amount, decimal balance)
        {
            Type = type;
            Amount = amount;
            CurrentBalance = balance;
            TransactionDate = date;
        }

        string GetTransactionDetails()
        {
            return $"Transaction Type: {Type}, Amount: {Amount}, Current Balance: {CurrentBalance}";
        }

        string GetTransactionType()
        {
            return Type;
        }

        decimal GetAmount()
        {
            return Amount;
        }
        public decimal GetCurrentBalance()
        {
                return CurrentBalance;
        }
    }


}
