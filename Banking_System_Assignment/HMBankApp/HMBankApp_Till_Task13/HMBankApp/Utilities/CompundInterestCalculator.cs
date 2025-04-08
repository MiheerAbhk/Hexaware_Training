using System;

namespace HMBankApp.Utilities;

public class CompoundInterestCalculator
{
    public void CalculateFutureBalances()
    {
        Console.Write("Enter number of customers to process: ");
        int customerCount = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= customerCount; i++)
        {
            Console.WriteLine($"\nCustomer {i}:");

            Console.Write("Enter initial balance: $");
            double initialBalance = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter annual interest rate (in %): ");
            double interestRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter number of years: ");
            int years = Convert.ToInt32(Console.ReadLine());

            double futureBalance = initialBalance * Math.Pow(1 + interestRate / 100, years);

            Console.WriteLine($"Future balance after {years} years: ${futureBalance:F2}");
        }

        Console.WriteLine("\nAll customer calculations complete.");
    }
}
