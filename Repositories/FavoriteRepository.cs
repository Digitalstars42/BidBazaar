using System.ComponentModel;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Repositories
{

    public interface IFavoriteRepository
    {
        public void Create(Favorites favorite);
        public IEnumerable<Favorites> Get();
        public IEnumerable<Favorites> GetById(int Id);

    }
    public class FavoriteRepository : BaseRepository, IFavoriteRepository
    {
        public void Create(Favorites favorite)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "INSERT INTO Favorites(user_id, item_id) VALUES (@User_id, @Item_id)";
                var insertedfavorite = new
                {
                    User_id = favorite.User_id,
                    Item_id = favorite.Item_id,
                };
                var rowsAffected = connection.Execute(sql, insertedfavorite);
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            }
        }
        public IEnumerable<Favorites> Get()
        {
            var sql = "select * from Favorites";
            var products = new List<Favorites>();
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var favorite = new Favorites
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("favorite_id")),
                                User_id = reader.GetInt32(reader.GetOrdinal("user_id")),
                                Item_id = reader.GetInt32(reader.GetOrdinal("item_id"))
                            };
                            products.Add(favorite);
                        }
                    }
                }
            }
            return products;
        }
        public IEnumerable<Favorites> GetById(int Id) { throw new NotSupportedException(); }

        IEnumerable<Favorites> IFavoriteRepository.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
