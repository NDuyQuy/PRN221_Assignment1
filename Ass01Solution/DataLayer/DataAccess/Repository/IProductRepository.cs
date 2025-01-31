using BussinessObject;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public Product? GetProduct(int id);
        public Product? GetProduct(string name);
        public void DeleteProduct(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public IEnumerable<Product> GetProductsByPrice(string price);
        public IEnumerable<Product> GetProductsByQuantity(int quantity);

    }
}
