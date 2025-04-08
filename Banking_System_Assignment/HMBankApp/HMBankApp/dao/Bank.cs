//using HMBankApp.entity;
//using HMBankApp.exception;
//using System.Text.RegularExpressions;

//namespace HMBankApp.dao
//{
//    public class Bank
//    {
//        private readonly Dictionary<long, BankAccount> accounts = new();

//        public Bank() { }

//        public void Run()
//        {
//            Console.WriteLine("Welcome to HMBankApp!");

//            bool exit = false;
//            while (!exit)
//            {
//                Console.WriteLine("\nAvailable commands:");
//                Console.WriteLine("1. create_account");
//                Console.WriteLine("2. deposit");
//                Console.WriteLine("3. withdraw");
//                Console.WriteLine("4. get_balance");
//                Console.WriteLine("5. transfer");
//                Console.WriteLine("6. getAccountDetails");
//                Console.WriteLine("7. exit");
//                Console.Write("Enter command: ");
//                int command = Convert.ToInt32(Console.ReadLine());

//                switch (command)
//                {
//                    case 1:
//                        CreateAccountMenu();
//                        break;
//                    case 2:
//                        PerformTransaction("deposit");
//                        break;
//                    case 3:
//                        PerformTransaction("withdraw");
//                        break;
//                    case 4:
//                        GetBalance();
//                        break;
//                    case 5:
//                        Transfer();
//                        break;
//                    case 6:
//                        GetAccountDetails();
//                        break;
//                    case 7:
//                        exit = true;
//                        Console.WriteLine("Exiting HMBankApp. Thank you!");
//                        break;
//                    default:
//                        Console.WriteLine("Invalid command.");
//                        break;
//                }
//            }
//        }

//        private void CreateAccountMenu()
//        {
//            Console.WriteLine("Choose account type:");
//            Console.WriteLine("1. Savings Account");
//            Console.WriteLine("2. Current Account");
//            Console.Write("Choice: ");
//            int choice = int.Parse(Console.ReadLine() ?? "0");

//            Console.Write("Enter First Name: ");
//            string firstName = Console.ReadLine() ?? "";

//            Console.Write("Enter Last Name: ");
//            string lastName = Console.ReadLine() ?? "";

//            Console.Write("Enter Email: ");
//            string email = Console.ReadLine() ?? "";
//            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
//            {
//                Console.WriteLine("Invalid email format.");
//                return;
//            }

//            Console.Write("Enter Phone Number: ");
//            string phone = Console.ReadLine() ?? "";
//            if (!Regex.IsMatch(phone, @"^\d{10}$"))
//            {
//                Console.WriteLine("Phone number must be 10 digits.");
//                return;
//            }

//            Console.Write("Enter Address: ");
//            string address = Console.ReadLine() ?? "";
//            int customerId = new Random().Next(1000, 9999);
//            Customer customer = new Customer(customerId, firstName, lastName, email, phone, address);

//            Console.Write("Enter Initial Balance: ");
//            double balance = double.Parse(Console.ReadLine() ?? "0");

//            BankAccount account;
//            switch (choice)
//            {
//                case 1:
//                    Console.Write("Enter Interest Rate (%): ");
//                    double rate = double.Parse(Console.ReadLine() ?? "0");
//                    account = new SavingsAccount(customer, balance, rate);
//                    break;
//                case 2:
//                    account = new CurrentAccount(customer, balance);
//                    break;
//                default:
//                    Console.WriteLine("Invalid account type.");
//                    return;
//            }

//            accounts[account.AccountNumber] = account;
//            Console.WriteLine($"Account created successfully. Account Number: {account.AccountNumber}");
//        }

//        private void PerformTransaction(string type)
//        {
//            Console.Write("Enter Account Number: ");
//            long accNo = long.Parse(Console.ReadLine() ?? "0");

//            if (!accounts.TryGetValue(accNo, out BankAccount? account))
//            {
//                Console.WriteLine("Account not found.");
//                return;
//            }

//            Console.Write($"Enter amount to {type}: ");
//            float amount = float.Parse(Console.ReadLine() ?? "0");

//            try
//            {
//                if (type == "deposit") account.Deposit(amount);
//                else account.Withdraw(amount);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"{type} failed: {ex.Message}");
//            }
//        }

//        private void GetBalance()
//        {
//            Console.Write("Enter Account Number: ");
//            long accNo = long.Parse(Console.ReadLine() ?? "0");

//            if (accounts.TryGetValue(accNo, out BankAccount? account))
//                Console.WriteLine($"Current Balance: {account.GetBalance():F2}");
//            else
//                Console.WriteLine("Account not found.");
//        }

//        private void Transfer()
//        {
//            Console.Write("Enter Sender Account Number: ");
//            long fromAcc = long.Parse(Console.ReadLine() ?? "0");
//            Console.Write("Enter Receiver Account Number: ");
//            long toAcc = long.Parse(Console.ReadLine() ?? "0");

//            if (!accounts.TryGetValue(fromAcc, out BankAccount? sender) || !accounts.TryGetValue(toAcc, out BankAccount? receiver))
//            {
//                Console.WriteLine("One or both account numbers are invalid.");
//                return;
//            }

//            Console.Write("Enter amount to transfer: ");
//            float amount = float.Parse(Console.ReadLine() ?? "0");

//            try
//            {
//                sender.Withdraw(amount);
//                receiver.Deposit(amount);
//                Console.WriteLine("Transfer successful.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Transfer failed: {ex.Message}");
//            }
//        }

//        private void GetAccountDetails()
//        {
//            Console.Write("Enter Account Number: ");
//            long accNo = long.Parse(Console.ReadLine() ?? "0");

//            if (accounts.TryGetValue(accNo, out BankAccount? account))
//                account.PrintInfo();
//            else
//                Console.WriteLine("Account not found.");
//        }
//    }
//}
