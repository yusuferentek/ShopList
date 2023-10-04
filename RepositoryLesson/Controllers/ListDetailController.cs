using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLesson.Interfaces;
using RepositoryLesson.Models;

namespace RepositoryLesson.Controllers
{
    public class ListDetailController : Controller
	{

		private readonly IShopListMappingRepository _repository;

		public ListDetailController(IShopListMappingRepository repository)
		{
			_repository=repository;
		}

		[Authorize(Roles ="Admin")]
		public IActionResult ListDetail(Lists list)
		{

            List<ShopListProductMapping> prdcts = _repository.Find(a => a.ShopListId==list.Id).ToList();
			TempData["listId"]=list.Id;
			return View(prdcts);
		}

		[Authorize(Roles ="Admin")]
        public IActionResult AddShopListMap()
        {

			return View();
        }

		[Authorize(Roles ="Admin")]
		[HttpPost]
        public IActionResult AddShopListMap(ShopListProductMapping prd)
		{
			prd.ShopListId = Convert.ToInt32(TempData["listId"]);
			_repository.Add(prd);
			return RedirectToAction("ListDetail");
		}

    }
}
