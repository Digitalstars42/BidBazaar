using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Repositories
{
    public interface IUserRepository
    {
        public Users Create(Users user);
        public IEnumerable<Users> Get();
        public IEnumerable<Users> GetById(int Id);

    }
    public class UserRepository : BaseRepository, IUserRepository
    {
        public Users Create(Users user)
        {
            throw new NotSupportedException();
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
                                Firstname = reader.GetString(reader.GetOrdinal("first_name")),
                                Lastname = reader.GetString(reader.GetOrdinal("last_name")),
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

        Users IUserRepository.Create(Users User)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Users> IUserRepository.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
