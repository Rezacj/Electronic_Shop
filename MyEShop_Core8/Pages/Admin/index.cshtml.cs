using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEShop_Core8.Data;
using MyEShop_Core8.Models;

namespace MyEShop_Core8.Pages.Admin
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private MyEShopContext _context;
        public IndexModel(MyEShopContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Products { get; set; }


        public void OnGet()
        {
            Products = _context.products.Include(p => p.items);
        }
        public void OnPost()
        {
        }
    }
}
