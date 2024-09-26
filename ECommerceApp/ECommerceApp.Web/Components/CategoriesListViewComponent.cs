using ECommerceApp.Data.Abstract;
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
            var model = _eCommerceRepository
                        .Products
                        .Select(c => c.Category)
                        .Distinct()
                        .OrderBy(c => c);
            return View(model);
        }
    }
}