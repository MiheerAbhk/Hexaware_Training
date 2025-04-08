using HMBankApp.entity;
using HMBankApp.exception;

public class SavingsAccount : Account
{
    private double interestRate;

    public SavingsAccount(double balance, Customer customer, double interestRate)
        : base("Savings", balance < 500 ? 500 : balance, customer)
    {
        this.interestRate = interestRate;
    }

    public override double CalculateInterest()
    {
        double interest = balance * interestRate;
        balance += interest;
        return interest;
    }

    public override void Withdraw(float amount)
    {
        if (balance - amount < 500)
            throw new InsufficientFundException("Minimum balance of 500 must be maintained.");
        base.Withdraw(amount);
    }
}
