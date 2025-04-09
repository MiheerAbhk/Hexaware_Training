using InsuranceManagement.entity;
using MyClaim = InsuranceManagement.entity.Claim;
using InsuranceManagementSystem.exception;
using InsuranceManagementSystem.util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using InsuranceManagementSystem.dao;
using System.Security.Claims;

namespace InsuranceManagement.dao
{
    public class PolicyServiceImpl : IPolicyService
    {
        private readonly SqlConnection _conn = DBConnUtil.GetConnection("db.properties");
        

        public bool CreatePolicy(Policy policy)
        {
            try
            {
                _conn.Open();
                string query = "INSERT INTO Policy(PolicyId, PolicyName) VALUES (@id, @name)";
                using SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@id", policy.PolicyId);
                cmd.Parameters.AddWithValue("@name", policy.PolicyName);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating policy: {ex.Message}");
                return false;
            }
            finally
            {
                if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
        }
        public Policy GetPolicy(int policyId)
        {
            try
            {
                _conn.Open();
                string query = "SELECT * FROM Policy WHERE PolicyId = @id";
                using SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@id", policyId);
                using SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    return new Policy(reader.GetInt32(0), reader.GetString(1));
                }
                throw new PolicyNotFoundException("Policy not found with ID: " + policyId);
            }
            catch(PolicyNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error getting policy: {ex.Message}");
                return null;
            }
            finally
            {
                if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
        }

        public List<Policy> GetAllPolicies()
        {
            List<Policy> policies = new List<Policy>();
            try
            {
                _conn.Open();
                string query = "SELECT * FROM Policy";
                using SqlCommand cmd = new SqlCommand(query, _conn);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    policies.Add(new Policy(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error fetchig all policies: {ex.Message}");
            }
            finally
            {
                if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return policies;
        }

        public bool UpdatePolicy(Policy policy)
        {
            try
            {
                _conn.Open();
                string query = "UPDATE Policy SET PolicyName = @name WHERE PolicyId = @id";
                using SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@name", policy.PolicyName);
                cmd.Parameters.AddWithValue("@id", policy.PolicyId);
                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                    throw new PolicyNotFoundException("No Policy found to update with ID: " + policy.PolicyId);
                return true;
            }
            catch (PolicyNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Eror updating policy: {ex.Message}");
                return false;
            }
            finally
            {
                if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
        }

        public bool DeletePolicy(int policyId)
        {
            try
            {
                _conn.Open();
                string query = "DELETE FROM Policy WHERE PolicyId = @id";
                using SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@id", policyId);
                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                    throw new PolicyNotFoundException("No policy found to delete with ID: " + policyId);
                return true;
            }
            catch (PolicyNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error deleting policy: {ex.Message}");
                return false;
            }
            finally
            {
                if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
        }

        public bool CreatePolicyWithClientAndPayment(Policy policy, Client client, Payment payment)
        {
            
            try
            {
                _conn.Open();

                // Insert Policy
                string policyQuery = "INSERT INTO Policy(PolicyId, PolicyName) VALUES (@id, @name)";
                using (SqlCommand cmd = new SqlCommand(policyQuery, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", policy.PolicyId);
                    cmd.Parameters.AddWithValue("@name", policy.PolicyName);
                    cmd.ExecuteNonQuery();
                }

                // Insert Client
                string clientQuery = "INSERT INTO Client(ClientId, ClientName, ContactInfo, PolicyId) VALUES (@id, @name, @contact, @policyId)";
                using (SqlCommand cmd = new SqlCommand(clientQuery, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", client.ClientId);
                    cmd.Parameters.AddWithValue("@name", client.ClientName);
                    cmd.Parameters.AddWithValue("@contact", client.ContactInfo);
                    cmd.Parameters.AddWithValue("@policyId", policy.PolicyId);
                    cmd.ExecuteNonQuery();
                }

                // Insert Payment
                string paymentQuery = "INSERT INTO Payment(PaymentId, PaymentDate, PaymentAmount, ClientId) VALUES (@id, @date, @amount, @clientId)";
                using (SqlCommand cmd = new SqlCommand(paymentQuery, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", payment.PaymentId);
                    cmd.Parameters.AddWithValue("@date", payment.PaymentDate);
                    cmd.Parameters.AddWithValue("@amount", payment.PaymentAmount);
                    cmd.Parameters.AddWithValue("@clientId", client.ClientId);
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating policy with client and payment: {ex.Message}");
                return false;
            }
            finally
            {
                if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
        }

        public bool FileClaim(MyClaim claim)
        {
            try
            {
                _conn.Open();
                string query = @"INSERT INTO Claim(ClaimId, ClaimNumber, DateFiled, ClaimAmount, Status, PolicyId, ClientId) 
                         VALUES (@id, @number, @date, @amount, @status, @policyId, @clientId)";
                using SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@id", claim.ClaimId);
                cmd.Parameters.AddWithValue("@number", claim.ClaimNumber);
                cmd.Parameters.AddWithValue("@date", claim.DateFiled);
                cmd.Parameters.AddWithValue("@amount", claim.ClaimAmount);
                cmd.Parameters.AddWithValue("@status", claim.Status);
                cmd.Parameters.AddWithValue("@policyId", claim.Policy.PolicyId);
                cmd.Parameters.AddWithValue("@clientId", claim.Client.ClientId);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error filing claim: {ex.Message}");
                return false;
            }
            finally
            {
                if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
        }

    }
}
