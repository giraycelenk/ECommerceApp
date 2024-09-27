using AutoMapper;
using ECommerceApp.Data.Concrete;

namespace ECommerceApp.Web.Models
{
    public class MapperProfile:Profile
    {
        

        public MapperProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}