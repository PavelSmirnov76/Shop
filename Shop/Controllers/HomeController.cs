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
