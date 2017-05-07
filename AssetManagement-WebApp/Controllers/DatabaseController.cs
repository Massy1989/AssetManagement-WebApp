using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement_WebApp.Controllers
{
    public class DatabaseController : Controller
    {
        [Route("Databases")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Your database description page.";
            return View();
        }
    }
}