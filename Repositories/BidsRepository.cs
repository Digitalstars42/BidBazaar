using System.ComponentModel;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Repositories
{

    public interface IBidRepository
    {
        public void Create(Bids bid);
        public IEnumerable<Bids> Get();
        public IEnumerable<Bids> GetById(int Id);

    }
    public class BidRepository : BaseRepository, IBidRepository
    {
        public void Create(Bids bid)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "INSERT INTO Bids(user_id, item_id, amount) VALUES (@User_id, @Item_id, @Amount)";
                var insertedbid = new
                {
                    User_id = bid.User_id,
                    Item_id = bid.Item_id,
                    Amount = bid.Amount
                };
                var rowsAffected = connection.Execute(sql, insertedbid);
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            }
        }
        public IEnumerable<Bids> Get()
        {
            var sql = "select * from Bids";
            var products = new List<Bids>();
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bid = new Bids
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("bid_id")),
                                User_id = reader.GetInt32(reader.GetOrdinal("user_id")),
                                Item_id = reader.GetInt32(reader.GetOrdinal("item_id")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("amount"))
                            };
                            products.Add(bid);
                        }
                    }
                }
            }
            return products;
        }
        public IEnumerable<Bids> GetById(int Id) { throw new NotSupportedException(); }

        IEnumerable<Bids> IBidRepository.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
