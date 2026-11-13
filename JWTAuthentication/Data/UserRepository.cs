using Dapper;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;
using System.Linq;

namespace JWTAuthentication.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDapperDBContext _context;
        public UserRepository(UserDapperDBContext context)
        {
            this._context = context;
        }

        public async Task<int> Create(User user)
        {
            //_context.Users.Add(user);
            //user.Id = _context.SaveChanges();

            //return user;


            int response;
            //string response = string.Empty;
            string query = "Insert into Users(Email,Name,Password) values (@Email,@Name,@Password)";
            var parameters = new DynamicParameters();
            
            parameters.Add("Email", user.Email, DbType.String);
            parameters.Add("Name", user.Name, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);
            using (var connectin = this._context.CreateConnection())
            {
                //var result =  await connectin.ExecuteAsync(query, parameters);
                //return result; // response = "pass";
                return await connectin.ExecuteAsync(query, parameters);

            }
            
            //return response;
        }

        public async Task<User> GetByEmail(string EmailId)
        {
            string query = "sp_getuserbyemail";
            using (var connectin = this._context.CreateConnection())
            {
                var user = await connectin.QueryFirstAsync<User>(query, new { EmailId }, commandType: CommandType.StoredProcedure);
                return user;
            }

            //return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public async Task<User> GetById(int id)
        {
            string query = "Select * From Users where Id=@id";
            using (var connectin = this._context.CreateConnection())
            {
                var user = await connectin.QueryFirstAsync<User>(query, new { id });
                return user;
            }
            //return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}