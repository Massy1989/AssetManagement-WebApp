using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebApp.Models
{
    public class AssetRepository : IAssetRepository
    {
        private AssetContext _context;
        private ILogger<AssetRepository> _logger;

        public AssetRepository(AssetContext context, ILogger<AssetRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IEnumerable<Asset> GetAllAssets()
        {
            _logger.LogInformation("Gett All Assets from the Database");

            var list = _context.Assets.Include(t => t.AssetType).ToList();
            return _context.Assets.ToList();
        }

        public IEnumerable<Asset> GetAllApplicationAssets()
        {
            var list = _context.Assets.Include(t => t.AssetType).Where(t => t.AssetType.Id == AssetTypeEnum.Application).ToList();
            return _context.Assets.ToList();
        }

        public IEnumerable<Asset> GetAllComponentAssets()
        {
            var list = _context.Assets.Include(t => t.AssetType).Where(t => t.AssetType.Id == AssetTypeEnum.Component).ToList();
            return _context.Assets.ToList();
        }

        public IEnumerable<Asset> GetAllDatabaseAssets()
        {
            var list = _context.Assets.Include(t => t.AssetType).Where(t => t.AssetType.Id == AssetTypeEnum.Database).ToList();
            return _context.Assets.ToList();
        }

        public IEnumerable<Asset> GetAllServerAssets()
        {
            var list = _context.Assets.Include(t => t.AssetType).Where(t => t.AssetType.Id == AssetTypeEnum.Server).ToList();
            return _context.Assets.ToList();
        }

        public IEnumerable<Asset> GetAllWorkstationAssets()
        {
            var list = _context.Assets.Include(t => t.AssetType).Where(t => t.AssetType.Id == AssetTypeEnum.Workstation).ToList();
            return _context.Assets.ToList();
        }

        public Asset GetAssetByName(string assetName, string username)
        {
            return _context.Assets
                .Include(t => t.AssetType)
                //.Where(t => t.Name == tripName && t.UserName == username)
                .Where(t => t.Name == assetName)
                .FirstOrDefault();
        }

        public void AddAsset(Asset asset)
        {
            _context.Add(asset);
        }

        public object GetAssetsByUsername(string name)
        {
            return _context.Assets
                //.Where(t => t.UserName == name)
                .ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
