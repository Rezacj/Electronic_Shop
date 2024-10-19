using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyEShop_Core8.Models;

namespace MyEShop_Core8.Models
{
    public class AddEditProductViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name ="نام کالا")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = "لطفا قیمت کالا را وارد کنید")]
        [Display(Name = "قیمت کالا")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "لطفا تعداد را وارد کنید")]
        [Display(Name = "تعداد")]
        public int QuantityInStock { get; set; }
        //public IFormFile Picture { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();

    }
}
