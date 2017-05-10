using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AssetManagementWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace AssetManagement_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IConfigurationRoot _config;
        private IAssetRepository _repository;

        public HomeController(IConfigurationRoot config, IAssetRepository repository)
        {
            _config = config;
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var data = _repository.GetAllAssets();
            return View(data);
        }

        //[HttpPost("")]
        //public IActionResult Index(Asset asset)
        //{
        //    var recordsInserted = _repository.AddAsset(asset);
        //    if(recordsInserted > 0)
        //    {
        //        return View("Index");
        //    }
        //    else
        //    {
        //        throw new Exception();
        //    }
        //}

        public IActionResult Error()
        {
            return View();
        }
    }
}
