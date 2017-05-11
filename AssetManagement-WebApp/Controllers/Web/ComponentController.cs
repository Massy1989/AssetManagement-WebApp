using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagementWebApp.Models;

namespace AssetManagement_WebApp.Controllers
{
    public class ComponentController : Controller
    {
        private IAssetRepository _repository;
        public ComponentController(IAssetRepository repository)
        {
            _repository = repository;
        }

        [Route("Components")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Components/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Components/Add")]
        public IActionResult Add(Asset asset)
        {
            var assetType = new AssetType(AssetTypeEnum.Component);
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

        [HttpGet("Components/Edit")]
        public IActionResult Edit(int assetId)
        {
            var asset = _repository.GetAssetById(assetId);
            return View(asset);
        }

        [HttpPost("Components/Edit")]
        public IActionResult Edit(Asset asset)
        {
            var assetType = new AssetType(AssetTypeEnum.Component);
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