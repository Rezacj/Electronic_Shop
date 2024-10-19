using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEShop_Core8.Data;
using MyEShop_Core8.Models;

namespace MyEShop_Core8.Pages.Admin
{
    public class Edit1Model : PageModel
    {
        private MyEShopContext _context;

        public Edit1Model(MyEShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }

        [BindProperty]
        public List<int> selectedGroups { get; set; }

        public List<int> GoupsProduct { get; set; }
        [HttpGet]
        public void OnGet(int id)
        {
            var product = _context.products.Include(p => p.items)
                .Where(p => p.id == id)
                .Select(s => new AddEditProductViewModel()
                {
                    Id = s.id,
                    Name = s.name,
                    Description = s.description,
                    QuantityInStock = s.items.quantityinstok,
                    Price = s.items.price
                }).FirstOrDefault();

            if (product != null)
            {
                Product = product;
                Product.Categories = _context.categories.ToList();
                GoupsProduct = _context.categoryToProducts.Where(c => c.Productid == id)
                    .Select(s => s.Categoryid).ToList();
            }
            //var product = _context.products.Include(p => p.items)
            //     .Where(p => p.id == id)
            //     .Select(s => new AddEditProductViewModel()
            //     {
            //         Id = s.id,
            //         Name = s.name,
            //         Description = s.description,
            //         QuantityInStock = s.items.quantityinstok,
            //         Price = s.items.price
            //     }).FirstOrDefault();

            //Product = product;
            //product.Categories = _context.categories.ToList();
            //GoupsProduct = _context.categoryToProducts.Where(c => c.Productid == id)
            //    .Select(s => s.Categoryid).ToList();

        }

        [HttpPost]
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var product = _context.products.Find(Product.Id);
            var item = _context.items.First(p => p.id == product.itemId);

            product.name = Product.Name;
            product.description = Product.Description;
            item.price = Product.Price;
            item.quantityinstok = Product.QuantityInStock;

            _context.SaveChanges();

            

            _context.categoryToProducts.Where(c => c.Productid == Product.Id).ToList()
               .ForEach(g => _context.categoryToProducts.Remove(g));
            _context.SaveChanges();

            if (selectedGroups.Any() && selectedGroups.Count > 0)
            {
                foreach (int gr in selectedGroups)
                {
                    _context.categoryToProducts.Add(new CategoryToProduct()
                    {
                        Categoryid = gr,
                        Productid = Product.Id
                    });
                }

                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
