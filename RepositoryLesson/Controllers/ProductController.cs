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
			//ProductDto pDto = new ProductDto();
			//var categoriess = new Categories();
			//pDto.CategoryList = new 
			return View(_repository.GetAll());
		}

        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct()
        {
			return View	();
        }

        [Authorize(Roles ="Admin")]
		[HttpPost]
		public IActionResult AddProduct(Products product)
		{
			
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
