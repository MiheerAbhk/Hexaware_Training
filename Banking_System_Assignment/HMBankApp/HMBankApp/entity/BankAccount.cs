using HMBankApp.entity;

namespace HMBankApp.entity
{
    public abstract class BankAccount
    {
        private static long nextAccountNumber = 1001;

        public long AccountNumber { get; private set; }
        public string CustomerName { get; protected set; }
        protected double balance;

        public Customer AccountHolder { get; set; } // Has-a Relationship

        public BankAccount()
        {
            AccountNumber = nextAccountNumber++;
        }

        public BankAccount(Customer customer, double balance)
        {
            AccountNumber = nextAccountNumber++;
            this.AccountHolder = customer;
            this.CustomerName = customer.FirstName + " " + customer.LastName;
            this.balance = balance;
        }


        public abstract void Deposit(float amount);
        public abstract void Withdraw(float amount);
        public abstract double CalculateInterest();

        public virtual void PrintInfo()
        {
            Console.WriteLine($"\n--- Account Info ---");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Balance: {balance:F2}");
            AccountHolder?.DisplayCustomerInfo();
        }

        public double GetBalance() => balance;
    }
}
