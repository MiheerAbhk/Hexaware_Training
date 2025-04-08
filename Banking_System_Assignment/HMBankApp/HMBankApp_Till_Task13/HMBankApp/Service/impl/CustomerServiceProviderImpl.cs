using HMBankApp.exception;
using HMBankApp.entity;

public class CustomerServiceProviderImpl : ICustomerServiceProvider
{
    protected Dictionary<long, Account> accounts = new();

    public virtual double GetAccountBalance(long accNo)
    {
        if (!accounts.TryGetValue(accNo, out var acc))
            throw new InvalidAccountException("Account not found.");
        return acc.GetBalance();
    }

    public virtual double Deposit(long accNo, float amount)
    {
        if (!accounts.TryGetValue(accNo, out var acc))
            throw new InvalidAccountException("Account not found.");
        acc.Deposit(amount);
        return acc.GetBalance();
    }

    public virtual double Withdraw(long accNo, float amount)
    {
        if (!accounts.TryGetValue(accNo, out var acc))
            throw new InvalidAccountException("Account not found.");
        acc.Withdraw(amount);
        return acc.GetBalance();
    }

    public virtual void Transfer(long from, long to, float amount)
    {
        if (!accounts.TryGetValue(from, out var fromAcc))
            throw new InvalidAccountException("Sender account not found.");

        if (!accounts.TryGetValue(to, out var toAcc))
            throw new InvalidAccountException("Receiver account not found.");

        fromAcc.Withdraw(amount);
        toAcc.Deposit(amount);
    }

    public virtual void GetAccountDetails(long accNo)
    {
        if (!accounts.TryGetValue(accNo, out var acc))
            throw new InvalidAccountException("Account not found.");
        acc.PrintInfo();
    }
}
