using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement_WebApp.Controllers
{
    public class ServerController : Controller
    {
        [Route("Servers")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Your server description page.";
            return View();
        }
    }
}