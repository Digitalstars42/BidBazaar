using System.ComponentModel;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Repositories
{

    public interface ICommentRepository
    {
        public void Create(Comments comment);
        public IEnumerable<Comments> Get();
        public IEnumerable<Comments> GetById(int Id);

    }
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public void Create(Comments comment)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "INSERT INTO Comments(user_id, item_id) VALUES (@User_id, @Item_id)";
                var insertedcomment = new
                {
                    User_id = comment.User_id,
                    Item_id = comment.Item_id,
                };
                var rowsAffected = connection.Execute(sql, insertedcomment);
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            }
        }
        public IEnumerable<Comments> Get()
        {
            var sql = "select * from Comments";
            var products = new List<Comments>();
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var comment = new Comments
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("comment_id")),
                                User_id = reader.GetInt32(reader.GetOrdinal("user_id")),
                                Item_id = reader.GetInt32(reader.GetOrdinal("item_id"))
                            };
                            products.Add(comment);
                        }
                    }
                }
            }
            return products;
        }
        public IEnumerable<Comments> GetById(int Id) { throw new NotSupportedException(); }

        IEnumerable<Comments> ICommentRepository.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
