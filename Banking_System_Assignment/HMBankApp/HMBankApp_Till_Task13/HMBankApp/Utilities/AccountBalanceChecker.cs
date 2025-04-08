using System;
using System.Collections.Generic;

namespace HMBankApp.Utilities;

public class AccountBalanceChecker
{
    
    private Dictionary<int, double> accounts = new Dictionary<int, double>()
    {
        { 1001, 15000.50 },
        { 1002, 7650.00 },
        { 1003, 22000.75 },
        { 1004, 5400.00 },
        { 1005, 12350.10 }
    };

    public void CheckBalance()
    {
        Console.WriteLine("Welcome to HM Bank Balance Checker");
        Console.WriteLine("--------------------------------------");

        while (true)
        {
            Console.Write("Enter your account number: ");
            bool isValidInput = int.TryParse(Console.ReadLine(), out int accountNumber);

            if (!isValidInput)
            {
                Console.WriteLine("Invalid input. Please enter a numeric account number.\n");
                continue;
            }

            if (accounts.ContainsKey(accountNumber))
            {
                double balance = accounts[accountNumber];
                Console.WriteLine($"Account found. Your current balance is: ${balance:F2}");
                break;
            }
            else
            {
                Console.WriteLine("Account number not found. Please try again.\n");
            }
        }

        Console.WriteLine("\nThank you for using HM Bank!");
    }
}
