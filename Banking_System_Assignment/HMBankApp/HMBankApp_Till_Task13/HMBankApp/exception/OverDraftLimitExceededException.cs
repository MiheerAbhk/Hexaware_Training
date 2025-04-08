using System;

namespace HMBankApp.exception
{
    public class OverDraftLimitExceededException : Exception
    {
        public OverDraftLimitExceededException(string message) : base(message) { }
    }
}
