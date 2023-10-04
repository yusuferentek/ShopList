using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLesson.Interfaces;
using RepositoryLesson.Models;

namespace RepositoryLesson.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Category()
        {
            return View(_repository.GetAll());
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult AddCategory(Categories category)
        {
            _repository.Add(category);
            return RedirectToAction("Category");
        }

        public IActionResult RemoveCategory(Categories category)
        {
            _repository.Remove(category);
            return RedirectToAction("Category");
        }
    }
}
