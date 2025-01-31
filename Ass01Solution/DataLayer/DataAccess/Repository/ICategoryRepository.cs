using BussinessObject;

namespace DataAccess.Repository
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetCategories();
        public Category ? GetCategory(int id);
        public Category? GetCategory(string name);
        public void DeleteCategory(int id);
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
    }
}
