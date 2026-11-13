using JWTAuthentication.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace JWTAuthentication.Data
{
    public class UserDapperDBContext 
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;
        public UserDapperDBContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.connectionstring = this._configuration.GetConnectionString("connection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionstring);
    }
}