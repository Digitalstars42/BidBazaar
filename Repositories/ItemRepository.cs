using System.ComponentModel;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Repositories
{
    
    public interface IItemRepository
    {
        public void Create(Items item);
        public IEnumerable<Items> Get();
        public IEnumerable<Items> GetById(int Id);

    }
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public void Create(Items item)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "INSERT INTO Items(name, description, price, availability_status) VALUES (@Name, @Description, @Price, @AvailibilityStatus)";
                var inserteditem = new
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    AvailibilityStatus = item.AvailibilityStatus
                };
                    var rowsAffected = connection.Execute(sql, inserteditem);
                    Console.WriteLine($"{rowsAffected} row(s) inserted.");
            }
        }
        public IEnumerable<Items> Get()
        {
            var sql = "select * from Items";
            var products = new List<Items>();
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Items
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("item_id")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Price = reader.GetDecimal(reader.GetOrdinal("price")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                AvailibilityStatus = reader.GetInt32(reader.GetOrdinal("availability_status"))
                            };
                            products.Add(item);
                        }
                    }
                }
            }
            return products;
        }
        public IEnumerable<Items> GetById(int Id) { throw new NotSupportedException(); }

        IEnumerable<Items> IItemRepository.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
