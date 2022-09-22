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

            return View(_context.Products.Include(p=> p.ProductInfos));
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> AddProduct(Product model)
        {
            if (ModelState.IsValid && model.Name != null)
            {
                await _context.Products.AddAsync(model);

                await _context.SaveChangesAsync();

                return RedirectToActionPermanent("List", "AdminPanel");
            }

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteProduct(long productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (product != null)
            {
                _context.Products.Remove(product);

                await _context.SaveChangesAsync();

                return RedirectToActionPermanent("List", "AdminPanel");
            }

            return NotFound();
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateProduct(long productId)
        {

            var product = await _context.Products.FirstOrDefaultAsync(p => productId == p.Id);

            if (product != null)
                return View(product);

            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToActionPermanent("List", "AdminPanel");
        }
    }
}
