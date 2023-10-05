using RepositoryLesson.Models;

namespace RepositoryLesson.Interfaces
{
    public interface IProductRepository : IGenericRepository<Products>
    {
        public List<Products> getProducts();

        public List<Categories> getCategories();
        public Categories getCategoryById(int? id);

    }
}
