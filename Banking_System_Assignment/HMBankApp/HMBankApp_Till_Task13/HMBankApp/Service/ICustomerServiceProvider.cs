public interface ICustomerServiceProvider
{
    double GetAccountBalance(long accountNumber);
    double Deposit(long accountNumber, float amount);
    double Withdraw(long accountNumber, float amount);
    void Transfer(long fromAcc, long toAcc, float amount);
    void GetAccountDetails(long accountNumber);
}
