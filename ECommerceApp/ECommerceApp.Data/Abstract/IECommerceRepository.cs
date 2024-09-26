using ECommerceApp.Data.Concrete;

namespace ECommerceApp.Data.Abstract
{
    public interface IECommerceRepository
    {
        IQueryable<Product> Products {get;}
        IQueryable<Category> Categories {get;}

        void CreateProduct(Product entity);
    }
}