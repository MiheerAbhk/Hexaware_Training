using System;

namespace HMBankApp.Utilities;

public class ATMTransactionSimulator
{
    public void StartTransaction()
    {
        Console.WriteLine("=== Welcome to HMTech ATM ===");

        Console.Write("Enter your current balance: $");
        double balance = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nSelect an option:");
        Console.WriteLine("1. Check Balance");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Deposit");
        Console.Write("Enter your choice (1/2/3): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            Console.WriteLine($"\nYour current balance is: ${balance:F2}");
        }
        else if (choice == 2)
        {
            Console.Write("Enter amount to withdraw: ");
            double withdrawAmount = Convert.ToDouble(Console.ReadLine());

            if (withdrawAmount <= balance)
            {
                if (withdrawAmount % 100 == 0 || withdrawAmount % 500 == 0)
                {
                    balance -= withdrawAmount;
                    Console.WriteLine($"Withdrawal successful. New balance: ${balance:F2}");
                }
                else
                {
                    Console.WriteLine("Withdrawal amount must be in multiples of 100 or 500.");
                }
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }
        else if (choice == 3)
        {
            Console.Write("Enter amount to deposit: $");
            double depositAmount = Convert.ToDouble(Console.ReadLine());

            balance += depositAmount;
            Console.WriteLine($"Deposit successful. New balance: ${balance:F2}");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }

        Console.WriteLine("\n=== Thank you for using HMTech ATM ===");
    }
}
