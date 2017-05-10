using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagementWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace AssetManagement_WebApp.Controllers
{
    public class ApplicationController : Controller
    {
        private IAssetRepository _repository;
        public ApplicationController(IAssetRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Applications")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Applications/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Applications/Add")]
        public IActionResult Add(Asset asset)
        {
            var assetType = new AssetType(AssetTypeEnum.Application);
            asset.AssetType = assetType;

            var recordsInserted = _repository.AddAsset(asset);
            if (recordsInserted > 0)
            {
                return View("Index");
            }
            else
            {
                throw new Exception();
            }
        }

        public IActionResult Applications()
        {
            var applications = _repository.GetAllAssets().Where(t => t.AssetType.Id == AssetTypeEnum.Application);

            return View(applications);
        }
    }
}