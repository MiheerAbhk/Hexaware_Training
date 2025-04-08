using HMBankApp.dao;
using HMBankApp.entity;
using HMBankApp.exception;

namespace HMBankApp.app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBankRepository bank = new BankRepositoryImpl();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== HMBank DB Menu ===");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Get Balance");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. List All Accounts");
                Console.WriteLine("8. Calculate Interest");
                Console.WriteLine("9. Exit");
                Console.Write("Choice: ");
                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            int id = 0;

                            Console.Write("First Name: ");
                            string fname = Console.ReadLine();

                            Console.Write("Last Name: ");
                            string lname = Console.ReadLine();

                            Console.Write("Email: ");
                            string email = Console.ReadLine();

                            Console.Write("Phone: ");
                            string phone = Console.ReadLine();

                            Console.Write("Address: ");
                            string address = Console.ReadLine();

                            Console.Write("Account Type (1. Savings | 2. Current | 3. ZeroBalance): ");
                            int accType = int.Parse(Console.ReadLine());

                            Console.Write("Initial Balance: ");
                            float balance = float.Parse(Console.ReadLine());

                            Customer customer = new(id, fname, lname, email, phone, address);

                            bool created = bank.CreateAccount(customer, accType, balance);
                            Console.WriteLine(created ? " Account created successfully!" : " Account creation failed.");
                            break;

                        case "2":
                            Console.Write("Enter Account Number: ");
                            long depAcc = long.Parse(Console.ReadLine());

                            Console.Write("Deposit Amount: ");
                            float depAmt = float.Parse(Console.ReadLine());

                            Console.WriteLine($"New Balance: {bank.Deposit(depAcc, depAmt):F2}");
                            break;

                        case "3":
                            Console.Write("Enter Account Number: ");
                            long witAcc = long.Parse(Console.ReadLine());

                            Console.Write("Withdraw Amount: ");
                            float witAmt = float.Parse(Console.ReadLine());

                            Console.WriteLine($"New Balance: {bank.Withdraw(witAcc, witAmt):F2}");
                            break;

                        case "4":
                            Console.Write("Enter Account Number: ");
                            long balAcc = long.Parse(Console.ReadLine());

                            Console.WriteLine($"Balance: {bank.GetAccountBalance(balAcc):F2}");
                            break;

                        case "5":
                            Console.Write("From Account Number: ");
                            long from = long.Parse(Console.ReadLine());

                            Console.Write("To Account Number: ");
                            long to = long.Parse(Console.ReadLine());

                            Console.Write("Amount to Transfer: ");
                            float amt = float.Parse(Console.ReadLine());

                            if (bank.Transfer(from, to, amt))
                                Console.WriteLine(" Transfer successful.");
                            break;

                        case "6":
                            Console.Write("Enter Account Number: ");
                            long detAcc = long.Parse(Console.ReadLine());

                            bank.GetAccountDetails(detAcc).PrintInfo();
                            break;

                        case "7":
                            var accounts = bank.ListAccounts();
                            foreach (var acc in accounts)
                            {
                                Console.WriteLine("---------------------------------");
                                acc.PrintInfo();
                            }
                            break;

                        case "8":
                            float interest = bank.CalculateInterest();
                            Console.WriteLine($" Total Interest Added: {interest:F2}");
                            break;

                        case "9":
                            exit = true;
                            Console.WriteLine(" Exiting... Goodbye!");
                            break;

                        default:
                            Console.WriteLine(" Invalid choice. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error: {ex.Message}");
                }
            }
        }
    }
}
