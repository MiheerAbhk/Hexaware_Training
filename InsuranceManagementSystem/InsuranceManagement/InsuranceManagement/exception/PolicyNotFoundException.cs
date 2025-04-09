using System;

namespace InsuranceManagementSystem.exception
{
    public class PolicyNotFoundException : Exception
    {
        public PolicyNotFoundException(string message) : base(message) { }
    }
}
