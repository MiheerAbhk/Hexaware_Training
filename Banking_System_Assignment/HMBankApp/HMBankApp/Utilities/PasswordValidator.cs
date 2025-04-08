using System;
using System.Linq;

namespace HMBankApp.Utilities;

public class PasswordValidator
{
    public void ValidatePassword()
    {
        Console.WriteLine("HM Bank Password Setup");
        Console.WriteLine("--------------------------");

        Console.Write("Enter a new password: ");
        string password = Console.ReadLine();

        
        bool isAtLeast8Chars = password.Length >= 8;
        bool hasUpperCase = password.Any(char.IsUpper);
        bool hasDigit = password.Any(char.IsDigit);

            if (!isAtLeast8Chars)
            {
                Console.WriteLine("Password must be at least 8 characters long.");
            }
            if (!hasUpperCase)
            {
                Console.WriteLine("Password must contain at least one uppercase letter.");
            }
            if (!hasDigit)
            {
                Console.WriteLine("Password must contain at least one digit.");
            }

            if (isAtLeast8Chars && hasUpperCase && hasDigit)
            {
                Console.WriteLine("Password is valid. Your account is secured!");
            }
            else
            {
                Console.WriteLine("Password is invalid. Please try again.");
            }
        }
}
