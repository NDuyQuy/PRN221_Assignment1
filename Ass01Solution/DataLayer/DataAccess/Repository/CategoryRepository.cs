using BussinessObject;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(Category category) => CategoryDAO.Instance.Add(category);

        public void DeleteCategory(int id) => CategoryDAO.Instance.Delete(id);

        public Category? GetCategory(int id) => CategoryDAO.Instance.GetCategory(id);

        public Category? GetCategory(string name) => CategoryDAO.Instance.GetCategory(name);

        public IEnumerable<Category> GetCategories() => CategoryDAO.Instance.GetCategories();

        public void UpdateCategory(Category category) => CategoryDAO.Instance.Update(category);
    }
}
