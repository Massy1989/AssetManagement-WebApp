using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagementWebApp.Models;

namespace AssetManagement_WebApp.Controllers
{
    public class DatabaseController : Controller
    {
        private IAssetRepository _repository;
        public DatabaseController(IAssetRepository repository)
        {
            _repository = repository;
        }

        [Route("Databases")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Databases/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Databases/Add")]
        public IActionResult Add(Asset asset)
        {
            var assetType = new AssetType(AssetTypeEnum.Database);
            asset.AssetType = assetType;

            var recordsInserted = _repository.AddAsset(asset);
            if (recordsInserted > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpGet("Databases/Edit")]
        public IActionResult Edit(int assetId)
        {
            var asset = _repository.GetAssetById(assetId);
            return View(asset);
        }

        [HttpPost("Databases/Edit")]
        public IActionResult Edit(Asset asset)
        {
            var assetType = new AssetType(AssetTypeEnum.Database);
            asset.AssetType = assetType;

            var recordsUpdated = _repository.UpdateAsset(asset);
            if (recordsUpdated > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception();
            }
        }
    }
}