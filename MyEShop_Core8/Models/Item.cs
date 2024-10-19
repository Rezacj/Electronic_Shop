using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEShop_Core8.Models
{
    public class Item
    {
        public int id { get; set; }
        
        public decimal price { get; set; }
        public int quantityinstok { get; set; }

        public Product product { get; set; }
    }
}
