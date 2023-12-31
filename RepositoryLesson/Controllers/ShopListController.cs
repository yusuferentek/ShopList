﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLesson.Interfaces;
using RepositoryLesson.Models;

namespace RepositoryLesson.Controllers
{
    public class ShopListController : Controller
    {
        private readonly IShopListRepository _repository;

        public ShopListController(IShopListRepository repository)
        {
            _repository = repository;
        }


        [Authorize]
        public IActionResult ShopLists()
        {
            return View(_repository.GetAll());
        }

        
        //public IActionResult AddShopList()
        //{
        //    return RedirectToAction("ShopLists");
        //}

        [Authorize]
        [HttpPost]
        public IActionResult ShopLists(Lists list,Users user)
        {
            var userID = HttpContext.Session.GetInt32("userID");
            int id = Convert.ToInt32(userID);
            list.ListStatus = 1;
            _repository.Add(_repository.AddList(list,id));
            return RedirectToAction("ShopLists");
        }

        public IActionResult Remove(Lists list)
        {
            _repository.Remove(list);
            return RedirectToAction("ShopLists");
        }

        [Authorize(Roles ="Admin")]
        public IActionResult GoShopping(Lists list) 
        {
            Lists ShopLst = _repository.getByID(list.Id);
            ShopLst.ListStatus = 2;
            _repository.Update(ShopLst, list.Id);
            return RedirectToAction("ShopLists");
        
        }

    }
}
