// filepath: /WordApp/WordApp/src/Models/User.cs
using System;

namespace WordApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        // Additional methods related to user operations can be added here
    }
}