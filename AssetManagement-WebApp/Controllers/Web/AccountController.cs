using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagementWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using AssetManagementWebApp.ViewModels;

namespace AssetManagement_WebApp.Controllers
{
    [Route("Authentication")]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authService;
        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public IActionResult Index(bool isLoginFailed = false)
        {
            var name = User.Identity.Name;
            return View(isLoginFailed);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
                    {
                        throw new ArgumentException();
                    }
                    var user = _authService.Login(model.Username, model.Password);
                    if (null != user)
                    {
                        var userClaims = new List<Claim>
                    {
                        new Claim("displayName", user.DisplayName),
                        new Claim("username", user.Username)
                    };
                        if (user.IsAdmin)
                        {
                            userClaims.Add(new Claim(ClaimTypes.Role, "Domain Admins"));
                        }
                        var principal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, _authService.GetType().Name));
                        await HttpContext.Authentication.SignInAsync("app", principal);
                        return Redirect("/");
                    }
                }
                catch (Exception ex)
                {
                    return Redirect("/Authentication/Login?isLoginFailed=true");
                    //ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }

        [Authorize(Roles = "Domain Admins")]
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("app");
            return Redirect("/");
        }
    }
}