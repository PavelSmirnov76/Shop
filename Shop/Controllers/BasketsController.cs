using GameStore.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers
{
    [Authorize]
    public class BasketsController:Controller
    {
        private readonly GameStoreContext _context;

        public BasketsController(GameStoreContext context)
        {
            _context = context;


        }

        public ViewResult List()
        {
            ViewBag.Title = "Корзина";

            var test = _context.Users.Include(b => b.Basket)
                    .Where(u => u.Email == HttpContext.User.Identity.Name)
                    .FirstOrDefault().Basket.Id;

            

            return View(_context.Baskets.Include(b => b.Products)
                    .Where(u => u.Id == test)
                    .FirstOrDefault());
        }
    }
}
