using ECommerceApp.Data.Concrete;

namespace ECommerceApp.Data.Abstract
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}