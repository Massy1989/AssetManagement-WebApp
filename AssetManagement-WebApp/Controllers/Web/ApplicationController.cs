using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagementWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Net.Http.Headers;

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
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpGet("Applications/Edit")]
        public IActionResult Edit(int assetId)
        {
            var asset = _repository.GetAssetById(assetId);
            return View(asset);
        }

        [HttpPost("Applications/Edit")]
        public IActionResult Edit(Asset asset)
        {
            var assetType = new AssetType(AssetTypeEnum.Application);
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

        [HttpDelete("Applications/Delete")]
        public IActionResult Delete(int id)
        {
            var asset = new Asset();
            asset.Id = id;

            var recordsUpdated = _repository.DeleteAsset(asset);
            if (recordsUpdated > 0)
            {
                return Ok();
                //return RedirectToAction("Index");
            }
            else
            {
                throw new Exception();
            }
        }

        //public IActionResult Applications()
        //{
        //    var applications = _repository.GetAllAssets().Where(t => t.AssetType.Id == AssetTypeEnum.Application);

        //    return View(applications);
        //}
    }
}