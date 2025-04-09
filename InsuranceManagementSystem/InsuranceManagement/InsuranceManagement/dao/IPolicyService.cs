using InsuranceManagement.entity;
using System.Collections.Generic;
using System.Security.Claims;
using MyClaim = InsuranceManagement.entity.Claim;

namespace InsuranceManagementSystem.dao
{
    public interface IPolicyService
    {
        bool CreatePolicy(Policy policy);
        Policy GetPolicy(int policyId);
        List<Policy> GetAllPolicies();
        bool UpdatePolicy(Policy policy);
        bool DeletePolicy(int policyId);
        bool CreatePolicyWithClientAndPayment(Policy policy, Client client, Payment payment);
        bool FileClaim(MyClaim claim);

    }
}
