using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEShop_Core8.Models
{
    public class Category
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }


        public ICollection<CategoryToProduct> categoryToProducts { get; set; }
    }
}
