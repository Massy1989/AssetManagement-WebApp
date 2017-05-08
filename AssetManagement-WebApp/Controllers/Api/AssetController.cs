using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagementWebApp.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;
using AssetManagementWebApp.ViewModels;

namespace AssetManagement_WebApp.Controllers
{
    [Route("/api/assets")]
    public class AssetController : Controller
    {
        private ILogger<AssetController> _logger;
        private IAssetRepository _repository;
        public AssetController(IAssetRepository repository, ILogger<AssetController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var assets = _repository.GetAllAssets();
                return Ok(Mapper.Map<IEnumerable<AssetViewModel>>(assets));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get All Assets: {ex}");
                return BadRequest("Error occurred");
            }
        }
    }
}