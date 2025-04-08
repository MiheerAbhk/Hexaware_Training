using HMBankApp.entity;

public interface IBankServiceProvider
{
    void CreateAccount(Customer customer, int accType, float balance);
    Account[] ListAccounts();
    void CalculateInterest();
}
