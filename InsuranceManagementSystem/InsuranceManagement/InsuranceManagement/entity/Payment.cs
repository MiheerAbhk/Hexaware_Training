using System;

namespace InsuranceManagement.entity
{
    public class Payment
    {
        private int paymentId;
        private DateTime paymentDate;
        private decimal paymentAmount;
        private Client client;

        public Payment() { }

        public Payment(int paymentId, DateTime paymentDate, decimal paymentAmount)
        {
            this.paymentId = paymentId;
            this.paymentDate = paymentDate;
            this.paymentAmount = paymentAmount;
        }

        public int PaymentId
        {
            get { return paymentId; }
            set { paymentId = value; }
        }

        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        public decimal PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; }
        }

        public Client Client
        {
            get { return client; }
            set { client = value; }
        }

        public override string ToString()
        {
            return $"PaymentId: {paymentId}, Date: {paymentDate.ToShortDateString()}, Amount: {paymentAmount}, Client: {client?.ClientName}";
        }
    }
}
