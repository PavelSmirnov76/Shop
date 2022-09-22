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
    public class ProductInfoController : Controller
    {
        private readonly GameStoreContext _context;

        public ProductInfoController(GameStoreContext context)
        {
            _context = context;
        }
        [Authorize]
        public ActionResult List(long productId)
        {
            var productInfo = _context.ProductInfos.FirstOrDefault(p => p.Id == productId);

            if (productInfo != null)
                return View(productInfo);

            return NotFound();
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> AddProductInfo(ProductInfo model)
        {
            if (ModelState.IsValid && model.Hedder != null)
            {
                await _context.ProductInfos.AddAsync(model);

                await _context.SaveChangesAsync();

                return RedirectToActionPermanent("List", "AdminPanel");
            }

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteProductInfo(long productInfoId)
        {
            var product = await _context.ProductInfos.FirstOrDefaultAsync(p => p.Id == productInfoId);

            if (product != null)
            {
                _context.ProductInfos.Remove(product);

                await _context.SaveChangesAsync();

                return RedirectToActionPermanent("List", "AdminPanel");
            }

            return NotFound();
        }
    }
}
