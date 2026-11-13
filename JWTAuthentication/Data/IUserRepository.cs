using JWTAuthentication;
using JWTAuthentication.Models;


namespace JWTAuthentication.Data
{
    public interface IUserRepository
    {
        Task<int> Create(User user);
        Task<User> GetByEmail(string email);
        Task<User> GetById(int id);
    }
}