using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEShop_Core8.Data;
using MyEShop_Core8.Models;

namespace MyEShop_Core8.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private MyEShopContext _context;

        public DeleteModel(MyEShopContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _context.products.FirstOrDefault(p => p.id == id);

        }

        public IActionResult OnPost()
        {
            var product = _context.products.Find(Product.id);
            var item = _context.items.First(p => p.id == product.itemId);
            _context.items.Remove(item);
            _context.products.Remove(product);

            _context.SaveChanges();

            //string filePath = Path.Combine(Directory.GetCurrentDirectory(),
            //    "wwwroot",
            //    "images",
            //    product.Id + ".jpg");
            //if (System.IO.File.Exists(filePath))
            //{
            //    System.IO.File.Delete(filePath);
            //}

            return RedirectToPage("Index");
        }
    }
}
