using RepositoryLesson.Models;

namespace RepositoryLesson.Interfaces
{
    public interface IShopListMappingRepository : IGenericRepository<ShopListProductMapping>
    {
        public List<Products> getProducts();

        public Categories getCategoryById(int? id);
        public Products getProductById(int? id);
    }
}
