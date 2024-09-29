using ECommerceApp.Data.Abstract;

namespace ECommerceApp.Data.Concrete
{
    public class EfOrderRepository : IOrderRepository
    {
        private ECommerceDbContext _context;
        public EfOrderRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public IQueryable<Order> Orders => _context.Orders;

        public void SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}