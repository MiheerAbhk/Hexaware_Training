using HMBankApp.entity;

public class Program
{
    public static void Main(string[] args)
    {
        BankServiceProviderImpl bank = new("HMBank", "Vivekananda Road");
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== HMBank Menu ===");
            Console.WriteLine("1. Create Account\n2. Deposit\n3. Withdraw\n4. Get Balance\n5. Transfer\n6. Get Account Details\n7. List Accounts\n8. Calculate Interest\n9. Exit");
            Console.Write("Choice: ");
            string ? choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Customer ID: ");
                        int id = int.Parse(Console.ReadLine());
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

                        Customer customer = new(id, fname, lname, email, phone, address);
                        Console.Write("Account Type (1. Savings/ 2. Current/ 3. ZeroBalance): ");
                        int accType = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Initial Balance: ");
                        float bal = float.Parse(Console.ReadLine());

                        bank.CreateAccount(customer, accType, bal);
                        break;

                    case "2":
                        Console.Write("Account Number: ");
                        long accNo1 = long.Parse(Console.ReadLine());
                        Console.Write("Deposit Amount: ");
                        float dep = float.Parse(Console.ReadLine());
                        Console.WriteLine($"Balance: {bank.Deposit(accNo1, dep):F2}");
                        break;

                    case "3":
                        Console.Write("Account Number: ");
                        long accNo2 = long.Parse(Console.ReadLine());
                        Console.Write("Withdraw Amount: ");
                        float wit = float.Parse(Console.ReadLine());
                        Console.WriteLine($"Balance: {bank.Withdraw(accNo2, wit):F2}");
                        break;

                    case "4":
                        Console.Write("Account Number: ");
                        long accNo3 = long.Parse(Console.ReadLine());
                        Console.WriteLine($"Balance: {bank.GetAccountBalance(accNo3):F2}");
                        break;

                    case "5":
                        Console.Write("From Account: ");
                        long from = long.Parse(Console.ReadLine());
                        Console.Write("To Account: ");
                        long to = long.Parse(Console.ReadLine());
                        Console.Write("Amount: ");
                        float amt = float.Parse(Console.ReadLine());
                        bank.Transfer(from, to, amt);
                        break;

                    case "6":
                        Console.Write("Account Number: ");
                        long accNo4 = long.Parse(Console.ReadLine());
                        bank.GetAccountDetails(accNo4);
                        break;

                    case "7":
                        foreach (var a in bank.ListAccounts())
                            a.PrintInfo();
                        break;

                    case "8":
                        bank.CalculateInterest();
                        break;

                    case "9":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
