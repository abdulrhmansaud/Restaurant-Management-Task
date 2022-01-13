using Restaurant_Management_Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.Authentication
{
   public interface AuthReopository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string Email, string password);

        User GetUserById(int id);

        Task<bool> UserExisits(string Email);
    }
}
