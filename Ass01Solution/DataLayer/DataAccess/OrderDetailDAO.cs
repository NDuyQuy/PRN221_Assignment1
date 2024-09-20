using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderDetailDAO
    {

        private static OrderDetailDAO? instance;
        private static readonly object instanceLock = new object();
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new OrderDetailDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrders() => new StoreContext().OrderDetails;

        public IEnumerable<OrderDetail> GetOrders(int orderId) => new StoreContext().OrderDetails.Where(od=>od.OrderId==orderId);
        public void Add(OrderDetail order)
        {
            try
            {
                var dbContext = new StoreContext();
                dbContext.Add(order);
                dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void Update(OrderDetail order)
        {

            try
            {
                var dbContext = new StoreContext();
                var _orderdt = dbContext.OrderDetails.FirstOrDefault(c=>(c.ProductId==order.ProductId&&c.OrderId==order.OrderId));
                if (_orderdt == null) throw new Exception("Invalid Order detail");
                else
                {
                    dbContext.OrderDetails.Update(order);
                    dbContext.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(OrderDetail order)
        {

            try
            {
                var dbContext = new StoreContext();
                dbContext.OrderDetails.Remove(order); 
                dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
