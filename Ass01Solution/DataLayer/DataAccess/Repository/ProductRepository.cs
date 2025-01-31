using BussinessObject;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product)=>ProductDAO.Instance.AddProduct(product);

        public void DeleteProduct(int id) => ProductDAO.Instance.DeleteProduct(id);

        public Product? GetProduct(int id) => ProductDAO.Instance.GetProduct(id);

        public Product? GetProduct(string name) => ProductDAO.Instance.GetProduct(name);
        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProducts();

        public IEnumerable<Product> GetProductsByPrice(string price) 
            =>ProductDAO.Instance.GetProductsByPrice(price);

        public IEnumerable<Product> GetProductsByQuantity(int quantity)
            =>ProductDAO.Instance.GetProductsByQuantity(quantity);

        public void UpdateProduct(Product product) => ProductDAO.Instance.Update(product);
    }
}
