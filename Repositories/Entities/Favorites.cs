using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Favorites
    {
        public int? Id { get; set; }
        public int User_id { get; set; }
        public int Item_id { get; set; }
    }
}
