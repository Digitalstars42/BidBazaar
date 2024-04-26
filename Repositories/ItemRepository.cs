using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Repositories
{
    
    public interface IItemRepository
    {
        public Items Create(Items item);
        public IEnumerable<Items> Get();
        public IEnumerable<Items> GetById(int Id);

    }
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public Items Create(Items item)
        {
            throw new NotSupportedException();
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

        Items IItemRepository.Create(Items item)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Items> IItemRepository.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
