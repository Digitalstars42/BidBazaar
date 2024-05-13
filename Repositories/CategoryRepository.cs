using System.ComponentModel;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Repositories
{

    public interface ICategoryRepository
    {
        public void Create(Categories category);
        public IEnumerable<Categories> Get();
        public IEnumerable<Categories> GetById(int Id);

    }
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public void Create(Categories category)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "INSERT INTO Categories(name, description) VALUES (@Name, @Description)";
                var insertedcategory = new
                {
                    Name = category.Name,
                    Description = category.Description,
                };
                var rowsAffected = connection.Execute(sql, insertedcategory);
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            }
        }
        public IEnumerable<Categories> Get()
        {
            var sql = "select * from Categories";
            var products = new List<Categories>();
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var category = new Categories
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("category_id")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                            };
                            products.Add(category);
                        }
                    }
                }
            }
            return products;
        }
        public IEnumerable<Categories> GetById(int Id) { throw new NotSupportedException(); }

        IEnumerable<Categories> ICategoryRepository.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
