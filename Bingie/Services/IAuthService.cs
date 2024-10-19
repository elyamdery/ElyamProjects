// Services/IAuthService.cs
using System.Threading.Tasks;
using Bingie.Models;

namespace Bingie.Services
{
    public interface IAuthService
    {
        Task<User> RegisterUser(string username, string password);
        Task<User> LoginUser(string username, string password);
    }
}
