using System;

namespace InsuranceManagement.entity
{
    public class User
    {
        private int userId;
        private string username;
        private string password;
        private string role;

        public User() { }

        public User(int userId, string username, string password, string role)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.role = role;
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public override string ToString()
        {
            return $"UserId: {userId}, Username: {username}, Role: {role}";
        }
    }
}
