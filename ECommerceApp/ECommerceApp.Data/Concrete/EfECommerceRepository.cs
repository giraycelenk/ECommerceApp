using ECommerceApp.Data.Abstract;

namespace ECommerceApp.Data.Concrete
{
    public class EfECommerceRepository : IECommerceRepository
    {
        private ECommerceDbContext _context;
        public EfECommerceRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public IQueryable<Product> Products => _context.Products;

        public void CreateProduct(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}