using System.ComponentModel.DataAnnotations;

namespace MyEShop_Core8.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="لطفا {0} را درست وارد کنید")]
        [MaxLength(300)]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }


        [Required(ErrorMessage = "لطفا {0} را درست وارد کنید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name ="تکرار کلمه عبور")]
        public string RePassword { get; set; }

    }
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را درست وارد کنید")]
        [MaxLength(300)]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
