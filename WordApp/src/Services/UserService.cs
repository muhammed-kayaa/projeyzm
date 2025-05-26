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
            try
            {
                // Sadece kullanıcı adına göre kontrol et
                var existingUser = _context.Users
                    .FirstOrDefault(u => u.Username == user.Username);

                if (existingUser != null)
                {
                    throw new System.Exception("Bu kullanıcı adı ile zaten bir kullanıcı kayıtlı.");
                }

                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                // Unique constraint hatası için özel mesaj
                if (dbEx.InnerException != null && dbEx.InnerException.Message.Contains("UQ_Users_Username"))
                {
                    System.Windows.Forms.MessageBox.Show("Bu kullanıcı adı ile zaten bir kullanıcı kayıtlı.", "Kayıt Hatası", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(dbEx.Message, "Kayıt Hatası", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Kayıt Hatası", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
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