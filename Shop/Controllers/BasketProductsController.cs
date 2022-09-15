using GameStore.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers
{
    [Authorize]
    public class BasketProductsController : Controller
    {
        private readonly GameStoreContext _context;

        public BasketProductsController(GameStoreContext context)
        {
            _context = context;


        }

        public ViewResult List()
        {
            ViewBag.Title = "Корзина";

            return View();
        }

        public ViewResult AddToBasket(long productId)
        {
            var basketId = _context.Users.Include(b => b.Basket)
                    .Where(u => u.Email == HttpContext.User.Identity.Name)
                    .FirstOrDefault().Basket.Id;
            _context.BasketProducts.Add(new BasketProduct
            {
                ProductId = productId,
                BasketId = basketId
            });

            _context.SaveChanges();

            return View();
        }
    }
}
