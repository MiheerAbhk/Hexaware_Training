using HMBankApp.entity;
using HMBankApp.exception;

public class Account
{
    protected static long lastAccNo = 1000;
    public long AccountNumber { get; private set; }
    public string AccountType { get; protected set; }
    protected double balance;
    public Customer Customer { get; private set; }

    public Account()
    {
        AccountNumber = ++lastAccNo;
    }

    public Account(string accountType, double initialBalance, Customer customer)
    {
        AccountNumber = ++lastAccNo;
        AccountType = accountType;
        balance = initialBalance;
        Customer = customer;
    }

    public virtual void Deposit(float amount) => balance += amount;
    public virtual void Withdraw(float amount)
    {
        if (balance >= amount) balance -= amount;
        else throw new InsufficientFundException("Insufficient balance.");
    }
    public virtual double GetBalance() => balance;
    public virtual double CalculateInterest() => 0.0;
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Account: {AccountNumber}, Type: {AccountType}, Balance: {balance}");
        Customer?.DisplayCustomerInfo();
    }
}
