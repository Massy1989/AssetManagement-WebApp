using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagementWebApp.Models;

namespace AssetManagement_WebApp.Controllers
{
    public class ServerController : Controller
    {
        private IAssetRepository _repository;
        public ServerController(IAssetRepository repository)
        {
            _repository = repository;
        }

        [Route("Servers")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Servers/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Servers/Add")]
        public IActionResult Add(Asset asset)
        {
            var assetType = new AssetType(AssetTypeEnum.Server);
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

        [HttpGet("Servers/Edit")]
        public IActionResult Edit(int assetId)
        {
            var asset = _repository.GetAssetById(assetId);
            return View(asset);
        }

        [HttpPost("Servers/Edit")]
        public IActionResult Edit(Asset asset)
        {
            var assetType = new AssetType(AssetTypeEnum.Server);
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