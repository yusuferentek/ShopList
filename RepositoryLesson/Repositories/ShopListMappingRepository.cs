using NuGet.Protocol.Core.Types;
using RepositoryLesson.Interfaces;
using RepositoryLesson.Models;

namespace RepositoryLesson.Repositories
{
    public class ShopListMappingRepository : GenericRepository<ShopListProductMapping>, IShopListMappingRepository
    {
        public ShopListMappingRepository(ShoppingDbContext context) : base(context)
        {
        }

        public Categories getCategoryById(int? id)
        {
            Categories categories = _context.Categories.Where(x => x.Id==id).FirstOrDefault();
            return categories;
        }

        public Products getProductById(int? id)
        {
            Products prdct = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            return prdct;
        }

        public List<Products> getProducts()
        {
            List<Products> products = _context.Products.ToList();
            return products;
        }
    }
}
