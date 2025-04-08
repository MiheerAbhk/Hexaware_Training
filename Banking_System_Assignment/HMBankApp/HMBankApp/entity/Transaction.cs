namespace HMBankApp.entity
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public long AccountNumber { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionType { get; set; }
        public float TransactionAmount { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"[{TransactionDateTime}] {TransactionType} of ${TransactionAmount:F2} - {Description}");
        }
    }
}
