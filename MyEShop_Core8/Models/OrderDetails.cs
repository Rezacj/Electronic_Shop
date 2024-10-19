using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEShop_Core8.Models
{
    public class OrderDetails
    {
        [Key]
        public int DetailID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Count { get; set; }


        public Order Order { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }
    }
}
