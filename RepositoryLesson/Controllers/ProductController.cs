using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLesson.Interfaces;
using RepositoryLesson.Models;

namespace RepositoryLesson.Controllers
{
    public class ProductController : Controller
	{
		private readonly IProductRepository _repository;

		public ProductController (IProductRepository repository)
		{
			_repository = repository;
		}

		[Authorize(Roles ="Admin")]
		public IActionResult Product()
		{
			List<Products> products = _repository.GetAll().ToList();
			for(int i = 0; i < products.Count; i++)
			{
				products[i].Category = _repository.getCategoryById(products[i].CategoryId);
			}
			return View(products);
		}

        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct()
        {
			List<Categories> categories= _repository.getCategories();
			return View	(categories);
        }

        [Authorize(Roles ="Admin")]
		[HttpPost]
		public IActionResult AddProduct(Products product)
		{
			product.Category = _repository.getCategoryById(product.CategoryId);
			product.IsPurchased = false;
			_repository.Add(product);
			return RedirectToAction("Product");
		}

		public IActionResult DeleteProduct(Products products)
		{
			_repository.Remove(products);
			return RedirectToAction("Product");
		}

	}
}
