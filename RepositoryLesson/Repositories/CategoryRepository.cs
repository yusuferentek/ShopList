using RepositoryLesson.Interfaces;
using RepositoryLesson.Models;

namespace RepositoryLesson.Repositories
{
    public class CategoryRepository : GenericRepository<Categories>, ICategoryRepository
    {
        public CategoryRepository(ShoppingDbContext context) : base(context) { }
    }
}
