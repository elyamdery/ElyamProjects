// Services/AuthService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Bingie.Models;

namespace Bingie.Services
{
    public class AuthService : IAuthService // Implementing the interface
    {
        private readonly List<User> _users = new();

        public async Task<User> RegisterUser(string username, string password)
        {
            if (_users.Exists(u => u.Username == username))
            {
                return null; // User already exists
            }

            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            _users.Add(user);
            await Task.CompletedTask; // Simulate async operation
            return user;
        }

        public async Task<User> LoginUser(string username, string password)
        {
            var user = _users.Find(u => u.Username == username);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user; // Successful login
            }

            return null; // Login failed
        }
    }
}
