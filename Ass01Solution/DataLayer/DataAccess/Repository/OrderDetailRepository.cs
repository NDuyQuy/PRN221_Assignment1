using BussinessObject;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderdetail) => OrderDetailDAO.Instance.Add(orderdetail);

        public void DeleteOrderDetail(OrderDetail orderdetail) => OrderDetailDAO.Instance.Delete(orderdetail);

        public IEnumerable<OrderDetail> GetOrderDetails() => OrderDetailDAO.Instance.GetOrders();

        public IEnumerable<OrderDetail> GetOrderDetails(int orderId) => OrderDetailDAO.Instance.GetOrders(orderId);

        public void UpdateOrderDetail(OrderDetail orderdetail) => OrderDetailDAO.Instance.Update(orderdetail);
    }
}
