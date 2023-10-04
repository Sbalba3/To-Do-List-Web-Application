
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using To_Do_List_Web_Application.Models;
using To_Do_List_Web_Application.Repositry;
using Microsoft.AspNetCore.Authorization;
using To_Do_List_Web_Application.Controllers;

namespace CRUDSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users user)
        {
            var userdb = _accountRepository.Find(user.User_Name, user.Password);
            if (user == null)
                return View(user);

            ClaimsIdentity claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claims.AddClaim(new Claim(ClaimTypes.Name, user.User_Name));
            

            ClaimsPrincipal principal = new ClaimsPrincipal(claims);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction(nameof(Index), "Tasks");
        }
        public IActionResult Signout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login), "Account");
        }
    }
}
