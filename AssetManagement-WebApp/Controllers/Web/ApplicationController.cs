using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement_WebApp.Controllers
{
    public class ApplicationController : Controller
    {
        [Route("Applications")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
    }
}