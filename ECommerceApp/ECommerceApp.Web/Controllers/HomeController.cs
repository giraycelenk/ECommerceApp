using ECommerceApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
namespace ECommerceApp.Web.Controllers
{
    public class HomeController:Controller
    {
        private IECommerceRepository _eCommerceRepository;
        public HomeController(IECommerceRepository eCommerceRepository)
        {
            _eCommerceRepository = eCommerceRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}