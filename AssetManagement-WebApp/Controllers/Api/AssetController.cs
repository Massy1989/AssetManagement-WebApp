using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagementWebApp.Models;

namespace AssetManagement_WebApp.Controllers
{
    [Route("/api/assets")]
    public class AssetController : Controller
    {
        private IAssetRepository _repository;
        public AssetController(IAssetRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var assets = _repository.GetAllAssets();
                //return Ok(Mapper.)
            }
            return Json("Test");
            //return View();
        }
    }
}