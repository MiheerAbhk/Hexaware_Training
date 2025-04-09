namespace InsuranceManagement.entity;

public class Policy
{
    public int PolicyId { get; set; }
    public string PolicyName { get; set; }
    public Client Client { get; set; }
    public Payment Payment { get; set; }


    public Policy() { }

    public Policy(int policyId, string policyName)
    {
        PolicyId = policyId;
        PolicyName = policyName;
    }

    public override string ToString()
    {
        return $"PolicyId: {PolicyId}, PolicyName: {PolicyName}";
    }
}
