using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SimpleWebApp.Models
{
    public class UserRepository : IUserRepository
    {
        private string _connectionString;
        public UserRepository()
        {
            var appSettings = AppSettingsJson.GetAppSettings();
            _connectionString = appSettings["ConnectionString"];
        }

        public IEnumerable<User> GetUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<User>("SELECT[Id],[initials],[name] FROM [user]");
            }
        }

        public User GetUser(long id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<User>("SELECT[Id],[initials],[name] FROM [user] WHERE id =@Id", new { Id = id }).SingleOrDefault();
            }              
        }

        public bool CreateUser(User user)
        {
            bool anyRowsAffected = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                anyRowsAffected = connection.Execute(@"INSERT user([initials],[name]) values (@Initials, @Name)", new { Initials = user.Initials, Name = user.Name }) > 0;
            }
            return anyRowsAffected;
        }

        public bool UpdateUser(User user)
        {
            bool anyRowsAffected = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                anyRowsAffected = connection.Execute("UPDATE [user] SET [initials] = @Initials ,[name] = @Name WHERE id = @Id", new { Id = user.Id, Initials = user.Initials, Name = user.Name }) > 0;
            }
            return anyRowsAffected;

        }
        public bool DeleteUser(long id)
        {
            bool anyRowsAffected = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                anyRowsAffected = connection.Execute("DELETE FROM [user] WHERE id = @Id", new { Id = id }) > 0;
            }
            return anyRowsAffected;
        }
    }
}
