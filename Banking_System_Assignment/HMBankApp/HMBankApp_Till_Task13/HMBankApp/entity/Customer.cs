using System.Text.RegularExpressions;

namespace HMBankApp.entity
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Customer() { }

        public Customer(int id, string fname, string lname, string email, string phone, string address)
        {
            if(!IsValidEmail(email))
                throw new ArgumentException("Invalid email format.");

            if (!IsValidPhone(phone))
                throw new ArgumentException("Invalid phone number. It should contain 10 digits only.");


            CustomerID = id;
            FirstName = fname;
            LastName = lname;
            Email = email;
            PhoneNumber = phone;
            Address = address;
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{10}$");
        }


        public void DisplayCustomerInfo()
        {
            Console.WriteLine($"Customer ID: {CustomerID}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Address: {Address}");
        }
    }
}
