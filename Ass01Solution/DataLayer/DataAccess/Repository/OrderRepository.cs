using BussinessObject;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrders();     
        public void DeleteOrder(int id) => OrderDAO.Instance.Delete(id);
        public void AddOrder(Order order) => OrderDAO.Instance.Add(order);  
        public void UpdateOrder(Order order) => OrderDAO.Instance.Update(order);
        public Order? GetOrder(int id) =>OrderDAO.Instance.GetOrder(id);
        public IEnumerable<Order> GetOrders(int memberId) =>OrderDAO.Instance.GetOrders(memberId);

        public List<T> GetSales<T>(DateTime startDate, DateTime endDate) where T : class => OrderDAO.Instance.GetSales<T>(startDate, endDate);
    }
}
