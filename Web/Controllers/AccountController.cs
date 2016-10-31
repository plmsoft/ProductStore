using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AnyPointObjects;
using HttpAnyPointServiceClient;
using Microsoft.AspNetCore.Mvc;
using www.ProductStore.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace www.ProductStore.Controllers
{
	[Authorize]
    public class AccountController : Controller
    {
		AnyPointServiceClient _anyPointServiceClient;

		[HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
				var url = @"http://localhost:8085/ProductStore_Users_WCFService/UserService/Get";
				_anyPointServiceClient = new AnyPointServiceClient(string.Empty, url);

				var userList = await _anyPointServiceClient.GetUsers();

				var user = userList.FirstOrDefault(d => d.UserName.Equals(model.UserName, StringComparison.OrdinalIgnoreCase) &&
				d.Password.Equals(model.Password, StringComparison.OrdinalIgnoreCase));

				if (user != null)
				{
					HttpContext.Session.SetInt32("CustomerId", user.ID);

					await Authenticate(model.UserName);
					return RedirectToLocal(returnUrl);
				}
            }

            return View(model);
        }

        [HttpGet]
		[Authorize]
		public async Task<IActionResult> Users(string returnUrl = null)
        {
			ViewData["ReturnUrl"] = returnUrl;

			var url = @"http://localhost:8085/ProductStore_Users_WCFService/UserService/Get";
			_anyPointServiceClient = new AnyPointServiceClient(string.Empty, url);

			var userList = await _anyPointServiceClient.GetUsers();
			
            return View(userList);
        }

		[HttpGet]
		[Authorize]
		public IActionResult UserEdit(int Id, string name, string password)
		{
			ViewBag.ID = Id;

			var user = new UserViewModel() { ID = Id, UserName = name, Password = password };

			return View(user);
		}

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UserEdit(UserViewModel user)
		{
			if (ModelState.IsValid)
			{
				if (user.ID == 0)
				{
					var url = @"http://localhost:8085/ProductStore_Users_WCFService/UserService/NEW";
					_anyPointServiceClient = new AnyPointServiceClient(string.Empty, url);

					await _anyPointServiceClient.CreateUser(user);
				}
				else
				{
					var url = @"http://localhost:8085/ProductStore_Users_WCFService/UserService/UPDATE";
					_anyPointServiceClient = new AnyPointServiceClient(string.Empty, url);

					await _anyPointServiceClient.ChangeUser(user);
				}

				return Redirect("~/Account/Users");
			}
			else
			{
				ViewBag.ID = user.ID;
			}

			return View(user);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> UserDelete(int Id)
		{
			var url = @"http://localhost:8085/ProductStore_Users_WCFService/UserService/DELETE";
			_anyPointServiceClient = new AnyPointServiceClient(string.Empty, url);

			await _anyPointServiceClient.DeleteUser(Id);

			return Redirect("~/Account/Users");
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.Authentication.SignOutAsync(AuthCookies.Cookies);
            return RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(string userName)
        {
           
            var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
                    };
            
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
           
            await HttpContext.Authentication.SignInAsync(AuthCookies.Cookies, new ClaimsPrincipal(id));
        }

        #region Helpers
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
    }
}
