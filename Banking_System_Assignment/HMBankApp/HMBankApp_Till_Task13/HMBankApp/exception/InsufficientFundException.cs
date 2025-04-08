using System;

namespace HMBankApp.exception
{
    public class InsufficientFundException : Exception
    {
        public InsufficientFundException(string message) : base(message) { }
    }
}
