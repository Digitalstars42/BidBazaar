using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BaseRepository
    {
        public String GetConnectionString()
        {
            return "Data Source=.\\sqlexpress;Initial Catalog=BidBazaar;Integrated Security=True;TrustServerCertificate=True;";
        }
    }
}
