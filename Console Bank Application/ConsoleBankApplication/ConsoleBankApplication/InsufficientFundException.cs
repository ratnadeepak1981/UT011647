using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApplication
{
    internal class InsufficientFundException : Exception
    {
        public decimal Balance;
        public InsufficientFundException(string message ,decimal Balance)
            : base(message)
        {
            this.Balance = Balance;

        }
    }
}
