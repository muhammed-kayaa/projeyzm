using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WordApp.Models;
using WordApp.Data;

namespace WordApp.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User AuthenticateUser(string username, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}