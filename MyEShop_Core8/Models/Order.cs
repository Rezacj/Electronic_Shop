using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEShop_Core8.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]

        public DateTime CreateDate { get; set; }
        public bool IsFinally { get; set; }

        [ForeignKey("UserID")]
        public Users Users { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
