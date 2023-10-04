using RepositoryLesson.Interfaces;
using RepositoryLesson.Models;

namespace RepositoryLesson.Repositories
{
    public class ShopListMappingRepository : GenericRepository<ShopListProductMapping>, IShopListMappingRepository
    {
        public ShopListMappingRepository(ShoppingDbContext context) : base(context)
        {
        }
    }
}
