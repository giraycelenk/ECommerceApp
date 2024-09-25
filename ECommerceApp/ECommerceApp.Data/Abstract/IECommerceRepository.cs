using ECommerceApp.Data.Concrete;

namespace ECommerceApp.Data.Abstract
{
    public interface IECommerceRepository
    {
        IQueryable<Product> Products {get;}

        void CreateProduct(Product entity);
    }
}