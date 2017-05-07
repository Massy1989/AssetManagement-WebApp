using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement_WebApp.Controllers
{
    public class ComponentController : Controller
    {
        [Route("Components")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Your component description page.";
            return View();
        }
    }
}