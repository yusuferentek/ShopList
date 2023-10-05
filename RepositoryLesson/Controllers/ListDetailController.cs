using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
			for(int i=0; i < prdcts.Count; i++)
			{
                prdcts[i].Product = _repository.getProductById(prdcts[i].ProductId);
				prdcts[i].Product.Category = _repository.getCategoryById(prdcts[i].Product.CategoryId);
            }

			ViewBag.ListStatus = list.ListStatus;
            TempData["listId"]=list.Id;
			return View(prdcts);
		}

		[Authorize(Roles ="Admin")]
        public IActionResult AddShopListMap()
        {
			List<Products> prd = _repository.getProducts();
            return View(prd);
        }

		[Authorize(Roles ="Admin")]
		[HttpPost]
        public IActionResult AddShopListMap(ShopListProductMapping prd)
        {

            prd.ShopListId = Convert.ToInt32(TempData["listId"]);
            _repository.Add(prd);
			return RedirectToAction("ListDetail", new { Id = prd.ShopListId});
		}

		[Authorize(Roles ="Admin")]
		[HttpPost]
		public IActionResult CompleteShopping(List<int> products)
		{
			for (int i = 0; i < products.Count; i++)
			{
				ShopListProductMapping shoplist = _repository.getByID(products[i]);
				shoplist.PurchaseStatus = true;
				_repository.Update(shoplist, shoplist.Id);
            }
            return RedirectToAction("ShopList","ShopLists");
        }

    }
}
