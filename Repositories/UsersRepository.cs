using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Repositories
{
    public interface IUserRepository
    {
        public void Create(Users user);
        public IEnumerable<Users> Get();
        public IEnumerable<Users> GetById(int Id);

    }
    public class UserRepository : BaseRepository, IUserRepository
    {
        public void Create(Users user)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "INSERT INTO Users(first_name, last_name, email, password) VALUES (@FirstName, @LastName, @Email, @Password)";
                var inserteduser = new
                {
                    FirstName = user.FirstName, 
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password
                };
                var rowsAffected = connection.Execute(sql, inserteduser);
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            }
        }
        public IEnumerable<Users> Get()
        {
            var sql = "select * from Users";
            var products = new List<Users>();
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new Users
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("user_id")),
                                FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                                LastName = reader.GetString(reader.GetOrdinal("last_name")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                Password = reader.GetString(reader.GetOrdinal("password"))
                            };
                            products.Add(user);
                        }
                    }
                }
            }
            return products;
        }
        public IEnumerable<Users> GetById(int Id) { throw new NotSupportedException(); }

        IEnumerable<Users> IUserRepository.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
