using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEShop_Core8.Models
{
    public class CategoryToProduct
    {
        
        public int Categoryid { get; set; }
        public int Productid { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }

    }
}
