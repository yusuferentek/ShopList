using RepositoryLesson.Interfaces;
using RepositoryLesson.ModelDto;
using RepositoryLesson.Models;

namespace RepositoryLesson.Repositories
{
    public class ProductRepository : GenericRepository<Products> , IProductRepository
    {
        public ProductRepository(ShoppingDbContext context) : base(context) { }


        //public Products AddProduct(Products product, int categoryId)
        //{
        //    Products nProduct = new Products();
        //    nProduct.IsPurchased = false;
        //    nProduct.CategoryName=product.CategoryName;
        //    nProduct.ProductName=product.ProductName;
        //    nProduct.
        //}

    }
    
}
