using HMBankApp.entity;
using HMBankApp.exception;

public class BankServiceProviderImpl : CustomerServiceProviderImpl, IBankServiceProvider
{
    private string branchName;
    private string branchAddress;

    public BankServiceProviderImpl(string name, string address)
    {
        this.branchName = name;
        this.branchAddress = address;
        accounts = new Dictionary<long, Account>(); // Override base accounts
    }

    public void CreateAccount(Customer customer, int accType, float balance)
    {
        Account acc = accType switch
        {
            1 => new SavingsAccount(balance, customer, 0.04),
            2 => new CurrentAccount(balance, customer, 1000),
            3 => new ZeroBalanceAccount(customer),
            _ => throw new InvalidAccountException("Invalid account type."),
        };

        if (accType == 1 && balance < 500)
        {
            throw new InsufficientFundException("Minimum balance of 500 must be maintained.");
        }

        if (accounts.ContainsKey(acc.AccountNumber))
        {
            Console.WriteLine($"Account number {acc.AccountNumber} already exists. Skipping duplicate.");
            return;
        }

        accounts.Add(acc.AccountNumber, acc);
        Console.WriteLine("-------Account created successfully.-------");
        acc.PrintInfo();
    }

    public Account[] ListAccounts()
    {
        return accounts.Values
                       .OrderBy(a => a.Customer.FirstName)
                       .ToArray();
    }

    public void CalculateInterest()
    {
        foreach (var acc in accounts.Values)
        {
            double interest = acc.CalculateInterest();
            if (interest > 0)
                Console.WriteLine($"Interest of {interest:F2} added to account {acc.AccountNumber}.");
        }
    }
}
