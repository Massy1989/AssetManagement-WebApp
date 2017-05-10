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

        [Route("Applications")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Applications/Add")]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Applications()
        {
            var applications = _repository.GetAllAssets().Where(t => t.AssetType.Id == AssetTypeEnum.Application);

            return View(applications);
        }
    }
}