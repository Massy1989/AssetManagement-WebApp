using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement_WebApp.Controllers
{
    public class WorkstationController : Controller
    {
        [Route("Workstations")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Your workstation description page.";
            return View();
        }
    }
}