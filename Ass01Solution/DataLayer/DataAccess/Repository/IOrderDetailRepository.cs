using BussinessObject;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetOrderDetails();
        public IEnumerable<OrderDetail> GetOrderDetails(int orderId);
        public void DeleteOrderDetail(OrderDetail orderdetail);
        public void AddOrderDetail(OrderDetail orderdetail);
        public void UpdateOrderDetail(OrderDetail orderdetail);
    }
}
