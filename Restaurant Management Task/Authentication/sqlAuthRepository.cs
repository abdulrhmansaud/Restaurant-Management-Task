using Microsoft.EntityFrameworkCore;
using Restaurant_Management_Task.Data;
using Restaurant_Management_Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.Authentication
{
    public class sqlAuthRepository : AuthReopository
    {

        private readonly reservationContext _context;

        public sqlAuthRepository(reservationContext context)
        {
            _context = context;

        }


        public async Task<User> Login(string Email, string password)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.Email == Email);
            if (user == null) return null;
            if (!VerifyPasswordHash(password, user.PasswordSalt, user.PasswordHash))
                return null;
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < ComputedHash.Length; i++)
                {
                    if (ComputedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passowrdSalt;
            CreatePasswordHash(password,out passwordHash,out passowrdSalt);
            user.PasswordSalt = passowrdSalt;
            user.PasswordHash = passwordHash;
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passowrdSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passowrdSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        public async Task<bool> UserExisits(string Email)
        {
            if (await _context.users.AnyAsync(x => x.Email == Email)) return true;
            return false;
        }

        public User GetUserById(int id)
        {
            return _context.users.Find(id);
        }
    }
}
