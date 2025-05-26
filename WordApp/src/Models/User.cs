// filepath: /WordApp/WordApp/src/Models/User.cs
using System;

namespace WordApp.Models
{
    public class User
    {
        public int UserId { get; set; } // Id yerine UserId olmalı
        public string Username { get; set; }
        public string Password { get; set; }

        // Parametresiz constructor ekle
        public User() { }

        // Eğer varsa, aşağıdaki gibi bir constructor da olabilir:
        public User(int userId, string username, string password)
        {
            UserId = userId;
            Username = username;
            Password = password;
        }
    }
}