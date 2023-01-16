using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InventoryManagement.Services;
using InventoryManagement.ViewModels;

namespace InventoryManagement.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var services = new AccountServices();
                var validUser = await services.ValidateUserAsync(model);
                if (validUser)
                {
                    var roles = await services.GetUserRolesFromDb(model.UserName);
                    var jwtToken = JwtProvider.GenerateToken(model.UserName, roles);
                    Response.Cookies.Set(new HttpCookie("jwtToken",jwtToken));
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = new AccountServices();
                await service.RegisterUserToDbAsync(model);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        //public ActionResult Logout()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Login");
        //}
    }

}