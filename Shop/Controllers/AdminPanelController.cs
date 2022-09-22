using GameStore.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminPanelController : Controller
    {
        private readonly GameStoreContext _context;

        public AdminPanelController(GameStoreContext context)
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

        public ViewResult List()
        {
            ViewBag.Title = "Админ панель";

            return View(_context.Products.Include(p => p.ProductInfos));
        }       
    }
}
