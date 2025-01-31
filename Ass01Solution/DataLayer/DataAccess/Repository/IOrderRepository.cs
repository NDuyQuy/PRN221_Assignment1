using BussinessObject;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetOrders();
        public IEnumerable<Order> GetOrders(int memberId);
        public Order? GetOrder(int id);
        public void DeleteOrder(int id);
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);
        public List<T> GetSales<T>(DateTime startDate, DateTime endDate) where T : class;
    }
}
