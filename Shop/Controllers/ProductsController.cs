using GameStore.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ProductsController:Controller
    {
        private readonly GameStoreContext _context;

        public ProductsController(GameStoreContext context)
        {
            _context = context;
        }
        [Authorize]
        public ViewResult List()
        {
            ViewBag.Title = "Страница с играми";

            var test2 = HttpContext.User.Identity.Name;
            var test23 = CookieAuthenticationDefaults.AuthenticationScheme;
            return View(_context.Products.Include(p=> p.ProductInfos));
        }

        [Authorize(Roles = "admin")]
        public ViewResult AddProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(model);

                _context.SaveChanges();
            }
            return View(model);
        }

    }
}
