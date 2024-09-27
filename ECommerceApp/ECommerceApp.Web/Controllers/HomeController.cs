using AutoMapper;
using ECommerceApp.Data.Abstract;
using ECommerceApp.Data.Concrete;
using ECommerceApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ECommerceApp.Web.Controllers
{
    public class HomeController:Controller
    {
        public int pageSize = 3;
        private readonly IECommerceRepository _eCommerceRepository;
        private readonly IMapper _mapper;
        public HomeController(IECommerceRepository eCommerceRepository,IMapper mapper)
        {
            _eCommerceRepository = eCommerceRepository;
            _mapper = mapper;
        }
        public IActionResult Index(string category, int page = 1)
        {
            return View(new ProductListViewModel {
                Products = _eCommerceRepository.GetProductsByCategory(category,page,pageSize)
                .Select(product => _mapper.Map<ProductViewModel>(product) ),
                PageInfo = new PageInfo{
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                    TotalItems = _eCommerceRepository.GetProductCount(category)
                }
            });
        }
    }
}