using System;
using System.Collections.Generic;

namespace HMBankApp.Utilities;

public class TransactiontTacker
{
    public void ManageTransactions()
    {
        List<string> transactionHistory = new List<string>();
        bool exit = false;

        Console.WriteLine("=== Welcome to the Transaction Tracker ===");

        while (!exit)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            string choiceInput = Console.ReadLine();

            if (!int.TryParse(choiceInput, out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number (1, 2, or 3).");
                continue;
            }

            switch (choice)
            {
                case 1: 
                    Console.Write("Enter deposit amount: ");
                    string depositInput = Console.ReadLine();
                    if (decimal.TryParse(depositInput, out decimal depositAmount) && depositAmount > 0)
                    {
                        transactionHistory.Add($"Deposited: ${depositAmount:F2}");
                        Console.WriteLine($"${depositAmount:F2} deposited successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid deposit amount.");
                    }
                    break;

                case 2: 
                    Console.Write("Enter withdrawal amount: ");
                    string withdrawInput = Console.ReadLine();
                    if (decimal.TryParse(withdrawInput, out decimal withdrawAmount) && withdrawAmount > 0)
                    {
                        transactionHistory.Add($"Withdrew: ${withdrawAmount:F2}");
                        Console.WriteLine($"${withdrawAmount:F2} withdrawn successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid withdrawal amount.");
                    }
                    break;

                case 3: 
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Please enter a valid option (1, 2, or 3).");
                    break;
            }
        }

        Console.WriteLine("\n=== Transaction History ===");
        if (transactionHistory.Count == 0)
        {
            Console.WriteLine("No transactions recorded.");
        }
        else
        {
            foreach (var transaction in transactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }

        Console.WriteLine("Thank you for using the Transaction Tracker!");
    }
}
