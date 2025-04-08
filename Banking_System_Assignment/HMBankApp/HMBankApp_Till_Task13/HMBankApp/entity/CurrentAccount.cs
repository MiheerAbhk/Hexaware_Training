using HMBankApp.entity;
using HMBankApp.exception;

public class CurrentAccount : Account
{
    private double overdraftLimit;

    public CurrentAccount(double balance, Customer customer, double overdraftLimit)
        : base("Current", balance, customer)
    {
        this.overdraftLimit = overdraftLimit;
    }

    public override void Withdraw(float amount)
    {
        if (balance + overdraftLimit < amount)
            throw new OverDraftLimitExceededException("Overdraft limit exceeded.");
        balance -= amount;
    }
}
