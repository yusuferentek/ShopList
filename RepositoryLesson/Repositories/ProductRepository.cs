using RepositoryLesson.Interfaces;
using RepositoryLesson.Models;

namespace RepositoryLesson.Repositories
{
    public class ProductRepository : GenericRepository<Products> , IProductRepository
    {
        public ProductRepository(ShoppingDbContext context) : base(context) { }


        public List<Categories> getCategories()
        {
            List<Categories> categories = _context.Categories.ToList();
            return categories;
        }

        public Categories getCategoryById(int? id)
        {
            Categories categories = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            return categories;
        }

        public List<Products> getProducts()
        {
            List<Products> products = _context.Products.ToList();
            return products;
        }

    }
    
}
