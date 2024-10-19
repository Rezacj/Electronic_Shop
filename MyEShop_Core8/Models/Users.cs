using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace MyEShop_Core8.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [MaxLength(300)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }


        public List<Order> Orders { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

    }
}
