using BussinessObject;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderDAO
    {
        private static OrderDAO? instance;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new OrderDAO();
                    return instance;
                }
            }
        }
        public IEnumerable<Order> GetOrders() => new StoreContext().Orders.Include(o=>o.Member);
        public IEnumerable<Order> GetOrders(int memberId)
        {
            var orders = new StoreContext().Orders.Where(order => order.MemberId == memberId);
            return orders;
        }
        public IEnumerable<Order> GetOrders(string memberEmail)
            => new StoreContext().Orders
            .Include(o=>o.Member)
            .Where(order => order.Member.Email == memberEmail);
        public Order? GetOrder(int id) => new StoreContext().Orders.Find(id);

        public void Add(Order order)
        {
            try
            {
                var dbContext = new StoreContext();
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var dbContext = new StoreContext();
                var _order = GetOrder(id);
                if (_order is null) throw new Exception("Order doesnt exist!");
                else
                {
                    dbContext.Orders.Remove(_order);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Order order)
        {
            try
            {
                var dbContext = new StoreContext();
                var _order = GetOrder(order.OrderId);
                if (_order is null) throw new Exception("Order doesnt exist!");
                else
                {
                    dbContext.Orders.Update(order);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<T> GetSales<T>(DateTime startDate, DateTime endDate) where T : class
        {
            using var _context = new StoreContext();
            var sdsql = new SqlParameter("@StartDate", startDate);
            var edsql = new SqlParameter("@EndDate", endDate);
            // Execute the stored procedure and map the results to SalesReport
            var salesReports = _context.Database.SqlQuery<T>(
                $"EXEC GetSalesReport {sdsql}, {edsql}"
            ).ToList();
            return salesReports;
        }
    }
}
