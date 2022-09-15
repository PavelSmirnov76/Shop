using GameStore.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly GameStoreContext _context;

        public HomeController(GameStoreContext context)
        {
            _context = context;

            if (!_context.Users.Any())
            {
                var user = new User
                {
                    Email = "admin@admin.ru",
                    Password = "admin",
                    Role = "admin",
                    Basket = new Basket()
                };

                _context.Users.Add(user);
            }
        }

        public ViewResult Index()
        {
            ViewBag.Title = "Начальная страница";

            var users = _context.Users.ToList();
            var bask = _context.Baskets.ToList();

            return View(_context.Products.Include(p => p.ProductInfos));
        }
    }
}
