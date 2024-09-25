using ECommerceApp.Data.Abstract;
using ECommerceApp.Web.Models;
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
            var products = _eCommerceRepository.Products.Select(p => new ProductViewModel{
                Id= p.Id,
                Name= p.Name,
                Description= p.Description,
                Price= p.Price,
            }).ToList();

            return View(new ProductListViewModel {
                Products = products
            });
        }
    }
}