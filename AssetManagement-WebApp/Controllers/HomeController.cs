using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AssetManagementWebApp.Models;

namespace AssetManagement_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IConfigurationRoot _config;
        private IAssetRepository _repository;

        //private AssetContext _context;
        public HomeController(IConfigurationRoot config, IAssetRepository repository) //AssetContext context)
        {
            _config = config;
            //_context = context;
            _repository = repository;
        }

        [Route("")]
        //[Route("Home/Index")]
        public IActionResult Index()
        {
            //var data = _context.Assets.ToList();
            var data = _repository.GetAllAssets();
            return View(data);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
