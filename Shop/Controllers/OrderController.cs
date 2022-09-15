using GameStore.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly GameStoreContext _context;

        public OrderController(GameStoreContext context)
        {
            _context = context;


        }
        [Authorize]
        public ViewResult Index()
        {
            ViewBag.Title = "Оплата";

            return View();
        }
    }
}
