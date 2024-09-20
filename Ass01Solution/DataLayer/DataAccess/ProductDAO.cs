using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class ProductDAO
    {

        private static ProductDAO? instance;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new ProductDAO();
                    return instance;
                }
            }
        }

        public Product? GetProduct(int id)
        {
            using (var context = new StoreContext())
            {
                return context.Products
                              .Include(p => p.Category)
                              .FirstOrDefault(p => p.ProductId == id);
            }
        }

        public Product? GetProduct(string name)
        {
            using (var context = new StoreContext())
            {
                return context.Products
                              .Include(p => p.Category)
                              .FirstOrDefault(p => p.ProductName == name);
            }
        }
        public IEnumerable<Product> GetProducts() => new StoreContext().Products.Include(c=>c.Category);

        public void AddProduct(Product product)
        {

            try
            {
                var dbContext = new StoreContext();
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(int id)
        {

            try
            {
                var dbContext = new StoreContext();
                var _product = GetProduct(id);
                if (_product == null) throw new Exception("Product doesnt exist!");
                else
                {
                    dbContext.Products.Remove(_product);
                    dbContext.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Update(Product product)
        {

            try
            {
                var dbContext = new StoreContext();
                var _product = GetProduct(product.ProductId);
                if (_product == null) throw new Exception("Product doesnt exist!");
                else
                {
                    dbContext.Update(product);
                    dbContext.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Product> GetProductsByPrice(string price)
            => new StoreContext().Products.Include(p=>p.Category).Where(p=>p.UnitPrice == price);
        public IEnumerable<Product> GetProductsByQuantity(int quantity)
            => new StoreContext().Products.Include(p=>p.Category).Where(p=>p.UnitsInStock==quantity);
    }
}
