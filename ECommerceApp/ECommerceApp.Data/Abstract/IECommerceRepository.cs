using ECommerceApp.Data.Concrete;

namespace ECommerceApp.Data.Abstract
{
    public interface IECommerceRepository
    {
        IQueryable<Product> Products {get;}
        IQueryable<Category> Categories {get;}

        void CreateProduct(Product entity);

        int GetProductCount(string category);
        IEnumerable<Product> GetProductsByCategory(string category, int page, int pageSize);
    }
}