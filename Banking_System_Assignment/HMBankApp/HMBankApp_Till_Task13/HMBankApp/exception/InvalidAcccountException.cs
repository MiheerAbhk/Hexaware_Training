using System;

namespace HMBankApp.exception
{
    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message) { }
    }
}
