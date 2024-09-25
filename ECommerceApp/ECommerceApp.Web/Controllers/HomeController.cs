using ECommerceApp.Data.Abstract;
using ECommerceApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
namespace ECommerceApp.Web.Controllers
{
    public class HomeController:Controller
    {
        public int pageSize = 3;
        private IECommerceRepository _eCommerceRepository;
        public HomeController(IECommerceRepository eCommerceRepository)
        {
            _eCommerceRepository = eCommerceRepository;
        }
        public IActionResult Index(int page = 1)
        {
            var products = _eCommerceRepository
                .Products
                .Skip((page-1)*pageSize)
                .Select(p => 
                    new ProductViewModel{
                        Id= p.Id,
                        Name= p.Name,
                        Description= p.Description,
                        Price= p.Price,
                    }).Take(pageSize);

            return View(new ProductListViewModel {
                Products = products,
                PageInfo = new PageInfo{
                    ItemsPerPage = pageSize,
                    TotalItems = _eCommerceRepository.Products.Count()
                }
            });
        }
    }
}