using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyEShop_Core8.Models
{
    public class Product
    {
        

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int itemId { get; set; }
        

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public Item items { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }


    }
}
