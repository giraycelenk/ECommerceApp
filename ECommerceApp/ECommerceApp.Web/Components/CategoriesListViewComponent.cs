using ECommerceApp.Data.Abstract;
using ECommerceApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECommerceApp.Web.Components
{
    public class CategoriesListViewComponent:ViewComponent
    {
        IECommerceRepository _eCommerceRepository;
        public CategoriesListViewComponent(IECommerceRepository eCommerceRepository)
        {
            _eCommerceRepository = eCommerceRepository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            var model = _eCommerceRepository
                        .Categories
                        .Select(c => new CategoryViewModel{
                            Id = c.Id,
                            Name = c.Name,
                            Url = c.Url,
                        }).ToList();
            return View(model);
            
        }
    }
}