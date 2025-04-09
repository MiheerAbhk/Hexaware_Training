using System;

namespace InsuranceManagement.entity;

public class Client
{
    private int clientId;
    private string clientName;
    private string contactInfo;
    private Policy policy;

    public Client() { }

    public Client(int clientId, string clientName, string contactInfo)
    {
        this.clientId = clientId;
        this.clientName = clientName;
        this.contactInfo = contactInfo;
    }

    public int ClientId
    {
        get { return clientId; }
        set { clientId = value; }
    }

    public string ClientName
    {
        get { return clientName; }
        set { clientName = value; }
    }

    public string ContactInfo
    {
        get { return contactInfo; }
        set { contactInfo = value; }
    }

    public Policy Policy
    {
        get { return policy; }
        set { policy = value; }
    }

    public override string ToString()
    {
        return $"ClientId: {clientId}, ClientName: {clientName}, ContactInfo: {contactInfo}, Policy: {policy?.ToString()}";
    }
}
