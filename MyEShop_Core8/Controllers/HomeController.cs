using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEShop_Core8.Data;
using MyEShop_Core8.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace MyEShop_Core8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyEShopContext _context;



        public HomeController(ILogger<HomeController> logger, MyEShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var product = _context.products.ToList();
            return View(product);
        }

        public IActionResult Detail(int id)
        {
            var product = _context.products
                .Include(p => p.items)
                .SingleOrDefault(s => s.id == id);

            if (product == null)
            {
                return NotFound();
            }

            var categories = _context.products
                .Where(p => p.id == id)
                .SelectMany(c => c.CategoryToProducts)
                .Select(ca => ca.Category)
                .ToList();
            var vm = new DetailViewModel()
            {
                Product = product,
                Categories = categories


            };
            return View(vm);
        }


        [Authorize]
        public IActionResult AddToCart(int itemId)
        {
            var product = _context.products.Include(p => p.items).SingleOrDefault(product => product.itemId == itemId);
            if (product != null)
            {
                int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _context.orders.FirstOrDefault(c => c.UserID == userid && !c.IsFinally);

                if (order != null)
                {
                    var orderDetail =
                            _context.ordersDetails.FirstOrDefault(d =>
                                d.OrderID == order.OrderID && d.ProductID == product.id);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _context.ordersDetails.Add(new OrderDetails()
                        {
                            OrderID = order.OrderID,
                            ProductID = product.id,
                            Price = product.items.price,
                            Count = 1
                        });
                    }
                }
                else
                {
                    order = new Order()
                    {
                        IsFinally = false,
                        CreateDate = DateTime.Now,
                        UserID = userid

                    };
                    _context.orders.Add(order);
                    _context.SaveChanges();
                    _context.ordersDetails.Add(new OrderDetails()
                    {
                        OrderID = order.OrderID,
                        ProductID = product.id,
                        Price = product.items.price,
                        Count = 1

                    });
                }
                _context.SaveChanges();
            }
            return RedirectToAction("ShowCart");
        }

        [Authorize]
        public IActionResult RemoveCart(int detailId)
        {
            var orderDetail = _context.ordersDetails.Find(detailId);
            if (orderDetail.Count > 1)
            {
                orderDetail.Count -= 1;
            }
            else
            {
                _context.Remove(orderDetail);
            }

            _context.SaveChanges();

            return RedirectToAction("ShowCart");
        }


        [Authorize]
        public IActionResult ShowCart()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.orders.Where(o => o.UserID == userId && !o.IsFinally)
                .Include(o => o.OrderDetails)
                .ThenInclude(c => c.Product).FirstOrDefault();
            return View(order);
        }
        public IActionResult ContactUs()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View("Error");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
