using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement_WebApp.Controllers
{
    public class AccountController : Controller
    {
        [Route("Account")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Your account description page.";
            return View();
        }

        [Route("Account/EditProfile")]
        public IActionResult EditProfile()
        {
            ViewData["Message"] = "Your edit profile description page.";
            return View();
        }
    }
}