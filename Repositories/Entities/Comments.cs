﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Comments
    {
        public int? Id { get; set; }
        public int User_id { get; set; }
        public int Item_id { get; set; } 
        public string Comment { get; set; }

    }
}
