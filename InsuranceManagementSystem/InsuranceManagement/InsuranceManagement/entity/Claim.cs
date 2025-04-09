using System;

namespace InsuranceManagement.entity
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public int ClaimNumber { get; set; }
        public DateTime DateFiled { get; set; }
        public double ClaimAmount { get; set; }
        public string Status { get; set; }
        public Policy Policy { get; set; }
        public Client Client { get; set; }

        public Claim() { }

        public Claim(int claimId, int claimNumber, DateTime dateFiled, double claimAmount, string status)
        {
            ClaimId = claimId;
            ClaimNumber = claimNumber;
            DateFiled = dateFiled;
            ClaimAmount = claimAmount;
            Status = status;

        }

        public override string ToString()
        {
            return $"Claim ID: {ClaimId}, Number: {ClaimNumber}, Amount: {ClaimAmount}, Date: {DateFiled}, Status: {Status}";
        }
    }
}
