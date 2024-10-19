using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEShop_Core8.Data;
using MyEShop_Core8.Models;

namespace MyEShop_Core8.Pages.Admin
{
    [Authorize]

    public class AddModel : PageModel
    {

        private MyEShopContext _context;

        public AddModel(MyEShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel product { get; set; }

        [BindProperty]
        public List<int> selectedGroups { get; set; }
        public void OnGet()
        {
            product = new AddEditProductViewModel()
            {
                Categories = _context.categories.ToList()
            };
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            var item = new Item()
            {
                price = product.Price,
                quantityinstok = product.QuantityInStock
            };
            _context.Add(item);
            _context.SaveChanges();

            var pro = new Product()
            {
                name = product.Name,
                items = item,
                description = product.Description,

            };
            _context.Add(pro);
            _context.SaveChanges();
            pro.itemId = pro.id;
            _context.SaveChanges();

            //if (Product.Picture?.Length > 0)
            //{
            //    string filePath = Path.Combine(Directory.GetCurrentDirectory(),
            //        "wwwroot",
            //        "images",
            //        pro.id + Path.GetExtension(Product.Picture.FileName));
            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        Product.Picture.CopyTo(stream);
            //    }
            //}
            if (selectedGroups.Any() && selectedGroups.Count > 0)
            {
                foreach (int gr in selectedGroups)
                {
                    _context.categoryToProducts.Add(new CategoryToProduct()
                    {
                        Categoryid = gr,
                        Productid = pro.id
                    });
                }

                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
