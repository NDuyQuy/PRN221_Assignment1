using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class CategoryDAO
    {

        private static CategoryDAO? instance;
        private static readonly object instanceLock = new object();
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new CategoryDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Category> GetCategories() => new StoreContext().Categories;
        public Category? GetCategory(int id) => new StoreContext().Categories.Find(id);
        public Category? GetCategory(string name) => new StoreContext().Categories.FirstOrDefault(c=>c.CategoryName == name);

        public void Add(Category category)
        {

            try
            {
                using var dbContext = new StoreContext();
                var _cate = dbContext.Categories.FirstOrDefault(c=>c.CategoryName==category.CategoryName);
                if (_cate != null) throw new Exception("Category already exist!");
                else
                {
                    dbContext.Categories.Add(category);
                    dbContext.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Update(Category category)
        {
            try
            {
                using var dbContext = new StoreContext();
                dbContext.Categories.Update(category);
                dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {

            try
            {
                using var dbContext = new StoreContext();
                var _category = dbContext.Categories.Find(id);
                if (_category == null) throw new Exception("Category Invalid");
                else
                {
                    dbContext.Categories.Remove(_category);
                    dbContext.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
