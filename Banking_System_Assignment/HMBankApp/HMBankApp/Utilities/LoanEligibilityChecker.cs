using System;

namespace HMBankApp.Utilities
{
    public class LoanEligibilityChecker
    {
        public void CheckEligibility()
        {
            Console.WriteLine("=== Loan Eligibility Checker ===");

            Console.Write("Enter your credit score: ");
            int creditScore = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your annual income ($): ");
            double annualIncome = Convert.ToDouble((Console.ReadLine()));

            if (creditScore > 700 && annualIncome >= 50000)
            {
                Console.WriteLine("Congratulations! You are eligible for a loan.");
            }
            else
            {
                Console.WriteLine("Sorry, you are not eligible for a loan.");
                if (creditScore <= 700)
                    Console.WriteLine("Reason: Credit score must be above 700.");
                if (annualIncome < 50000)
                    Console.WriteLine("Reason: Annual income must be at least $50,000.");
            }
        }
    }
}
