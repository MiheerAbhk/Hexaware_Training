using HMBankApp.entity;

public class ZeroBalanceAccount : Account
{
    public ZeroBalanceAccount(Customer customer)
        : base("ZeroBalance", 0, customer) { }

    public override double CalculateInterest()
    {
        return 0.0;
    }
}
