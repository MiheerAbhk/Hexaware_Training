using System;
using InsuranceManagement.entity;
using InsuranceManagementSystem.dao;
using InsuranceManagementSystem.exception;
using InsuranceManagement.dao;
using MyClaim = InsuranceManagement.entity.Claim;

namespace InsuranceManagementSystem.mainmod
{
    public class Program
    {
        static void Main(string[] args)
        {
            IPolicyService policyService = new PolicyServiceImpl();

            while (true)
            {
                Console.WriteLine("\n===== Insurance Management System =====");
                Console.WriteLine("1. Create Policy");
                Console.WriteLine("2. Get Policy by ID");
                Console.WriteLine("3. Get All Policies");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("6. File Claim");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                try
                {
                    switch (input)
                    {
                        case "1":
                            Console.Write("Enter Policy ID: ");
                            int createId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Policy Name: ");
                            string createName = Console.ReadLine();

                            // client info
                            Console.Write("Enter Client ID: ");
                            int clientId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Client Name: ");
                            string clientName = Console.ReadLine();
                            Console.Write("Enter Contact Info: ");
                            string contactInfo = Console.ReadLine();
                            Client client = new Client(clientId, clientName, contactInfo);

                            // payment info
                            Console.Write("Enter Payment ID: ");
                            int paymentId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Payment Date (yyyy-mm-dd): ");
                            DateTime paymentDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter Payment Amount: ");
                            decimal paymentAmount = decimal.Parse(Console.ReadLine());
                            Payment payment = new Payment(paymentId, paymentDate, paymentAmount);

                            Policy newPolicy = new Policy(createId, createName);

                            // ❗ Call correct method
                            if (((PolicyServiceImpl)policyService).CreatePolicyWithClientAndPayment(newPolicy, client, payment))
                            {
                                Console.WriteLine("Policy, Client, and Payment created successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Creation failed.");
                            }
                            break;

                        case "2":
                            Console.Write("Enter Policy ID to fetch: ");
                            int getId = int.Parse(Console.ReadLine());

                            Policy fetched = policyService.GetPolicy(getId);
                            Console.WriteLine("Policy Found: " + fetched);
                            break;

                        case "3":
                            Console.WriteLine("All Policies:");
                            foreach (Policy p in policyService.GetAllPolicies())
                            {
                                Console.WriteLine(p);
                            }
                            break;

                        case "4":
                            Console.Write("Enter Policy ID to update: ");
                            int updateId = int.Parse(Console.ReadLine());

                            Console.Write("Enter New Policy Name: ");
                            string updateName = Console.ReadLine();

                            Policy updatePolicy = new Policy(updateId, updateName);
                            if (policyService.UpdatePolicy(updatePolicy))
                            {
                                Console.WriteLine("Policy updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Policy update failed.");
                            }
                            break;

                        case "5":
                            Console.Write("Enter Policy ID to delete: ");
                            int deleteId = int.Parse(Console.ReadLine());

                            if (policyService.DeletePolicy(deleteId))
                            {
                                Console.WriteLine("Policy deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Policy deletion failed.");
                            }
                            break;

                        case "6":
                            Console.Write("Enter Claim ID: ");
                            int claimId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Claim Number: ");
                            int claimNumber = int.Parse(Console.ReadLine());

                            Console.Write("Enter Policy ID: ");
                            int policyId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Client ID: ");
                            int clId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Claim Date (yyyy-mm-dd): ");
                            DateTime claimDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter Claim Amount: ");
                            double claimAmount = double.Parse(Console.ReadLine());

                            Console.Write("Enter Claim Status: ");
                            string status = Console.ReadLine();

                            
                            Policy policy = ((PolicyServiceImpl)policyService).GetPolicy(policyId);
                            Client cl = new Client { ClientId = clId }; 

                           
                            MyClaim claim = new MyClaim
                            {
                                ClaimId = claimId,
                                ClaimNumber = claimNumber,
                                DateFiled = claimDate,
                                ClaimAmount = claimAmount,
                                Status = status,
                                Policy = policy,
                                Client = cl
                            };

                            if (((PolicyServiceImpl)policyService).FileClaim(claim))
                            {
                                Console.WriteLine("Claim filed successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to file claim.");
                            }
                            break;


                        case "7":
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                catch (PolicyNotFoundException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter valid numbers.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
            }
        }
    }
}
