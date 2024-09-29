using ECommerceApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Web.Controllers
{
    public class OrderController:Controller
    {
        private Cart cart;
        public OrderController(Cart cartService)
        {
            cart = cartService;
        }

        public IActionResult Checkout()
        {
            return View(new OrderModel() {Cart = cart});
        }
    }
}