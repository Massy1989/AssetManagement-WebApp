using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement_WebApp.Controllers
{
    public class AssetController : Controller
    {
        //[Route("Assets")]
        [HttpGet("Assets")]
        public IActionResult Index()
        {
            return Json("Test");
            //return View();
        }
    }
}