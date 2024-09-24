using Microsoft.AspNetCore.Mvc;
namespace ECommerceApp.Web.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}