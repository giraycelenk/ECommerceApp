using ECommerceApp.Data.Abstract;
using ECommerceApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index(string category, int page = 1)
        {
            return View(new ProductListViewModel {
                Products = _eCommerceRepository.GetProductsByCategory(category,page,pageSize).Select(p => 
                                new ProductViewModel{
                                    Id= p.Id,
                                    Name= p.Name,
                                    Description= p.Description,
                                    Price= p.Price,
                                }).Take(pageSize),
                PageInfo = new PageInfo{
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                    TotalItems = _eCommerceRepository.GetProductCount(category)
                }
            });
        }
    }
}