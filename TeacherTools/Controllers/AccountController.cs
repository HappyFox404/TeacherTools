using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using TeacherTools.Data;
using TeacherTools.Models;
using TeacherTools.ViewModels.Account;

namespace TeacherTools.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Авторизация";
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model) {
            ViewData["Title"] = "Авторизация";
            if (ModelState.IsValid)
            {
                switch (DatabaseLayer.EqualsAccount(new Account() { Login = model.Login, Password = model.Password })) {
                    case DatabaseLayer.AccountFindStatus.Found: {
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimsIdentity.DefaultNameClaimType, model.Login)
                            };
                            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

                            return RedirectToActionPermanent("Index", "Home");
                        } break;
                    case DatabaseLayer.AccountFindStatus.NotFound:
                        {
                            ModelState.AddModelError("", "Данный пользователь не найден");
                        } break;
                    case DatabaseLayer.AccountFindStatus.Incorrect:
                        {
                            ModelState.AddModelError("", "Ваш пароль не совпадает");
                        }
                        break;
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register() {
            ViewData["Title"] = "Регистрация";
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel model) {
            ViewData["Title"] = "Регистрация";
            if (ModelState.IsValid) 
            {
                if (DatabaseLayer.AddAccount(new Account() { Login = model.Login, Password = model.Password }))
                {
                    return RedirectToActionPermanent("Login");
                }
                ModelState.AddModelError("", "Данное имя пользователя занято");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
