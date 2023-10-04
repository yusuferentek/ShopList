using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RepositoryLesson.Interfaces;
using RepositoryLesson.Models;
using RepositoryLesson.Repositories;

namespace RepositoryLesson.Controllers
{
    public class SessionController : Controller
    {

        private readonly IUsersRepository repository;
        IOptions<JwtOptions> tokenOption;

        public SessionController(IOptions<JwtOptions> options, IUsersRepository _repo)
        {
            tokenOption = options;
            repository = _repo;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Users user)
        {
            Users isAuth =  repository.Login(user); 
            if(isAuth != null)
            {
                HttpContext.Session.SetInt32("userID", isAuth.Id);
                HttpContext.Session.SetString("Token", repository.GenerateToken(user,tokenOption));
                return RedirectToAction("ShopLists","ShopList");
            }else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı. E posta ya da Şifre Hatalı";
                return View();
            }
        }

        public IActionResult Signup()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Signup(Users user)
        {
            bool status = repository.Signup(user);
            if(status == true)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Mesaj = "Kayıt Başarısız";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
