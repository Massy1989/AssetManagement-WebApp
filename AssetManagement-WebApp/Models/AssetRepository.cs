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
        public IEnumerable<AssetCount> GetAllAssetCounts()
        {
            var list = new List<AssetCount>();
            var assetList = _context.Assets.Include(t => t.AssetType).ToList();
            AssetCount assetCount;

            //Applications
            assetCount = new AssetCount()
            {
                AssetType = new AssetType(AssetTypeEnum.Application)
            };
            assetCount.Quantity = assetList.Where(t => t.AssetType.Id == assetCount.AssetType.Id).ToList().Count;
            list.Add(assetCount);

            //Components
            assetCount = new AssetCount()
            {
                AssetType = new AssetType(AssetTypeEnum.Component)
            };
            assetCount.Quantity = assetList.Where(t => t.AssetType.Id == assetCount.AssetType.Id).ToList().Count;
            list.Add(assetCount);

            //Databases
            assetCount = new AssetCount()
            {
                AssetType = new AssetType(AssetTypeEnum.Database)
            };
            assetCount.Quantity = assetList.Where(t => t.AssetType.Id == assetCount.AssetType.Id).ToList().Count;
            list.Add(assetCount);

            //Servers
            assetCount = new AssetCount()
            {
                AssetType = new AssetType(AssetTypeEnum.Server)
            };
            assetCount.Quantity = assetList.Where(t => t.AssetType.Id == assetCount.AssetType.Id).ToList().Count;
            list.Add(assetCount);

            //Workstations
            assetCount = new AssetCount()
            {
                AssetType = new AssetType(AssetTypeEnum.Workstation)
            };
            assetCount.Quantity = assetList.Where(t => t.AssetType.Id == assetCount.AssetType.Id).ToList().Count;
            list.Add(assetCount);

            return list;
        }

        public IEnumerable<Asset> GetAllAssets()
        {
            _logger.LogInformation("Get All Assets from the Database");
            var list = _context.Assets.Include(t => t.AssetType).OrderBy(o => o.AssetType.Description).ThenBy(o => o.Name).ToList();
            return _context.Assets.OrderBy(o => o.AssetType.Description).ThenBy(o => o.Name).ToList();
        }

        //public IEnumerable<Asset> GetAllApplicationAssets()
        //{
        //    var list = _context.Assets.Include(t => t.AssetType).Where(t => t.AssetType.Id == AssetTypeEnum.Application).ToList();
        //    return _context.Assets.ToList();
        //}

        //public IEnumerable<Asset> GetAllComponentAssets()
        //{
        //    var list = _context.Assets.Include(t => t.AssetType).Where(t => t.AssetType.Id == AssetTypeEnum.Component).ToList();
        //    return _context.Assets.ToList();
        //}

        //public IEnumerable<Asset> GetAllDatabaseAssets()
        //{
        //    var list = _context.Assets.Include(t => t.AssetType).Where(t => t.AssetType.Id == AssetTypeEnum.Database).ToList();
        //    return _context.Assets.ToList();
        //}

        //public IEnumerable<Asset> GetAllServerAssets()
        //{
        //    var list = _context.Assets.Include(t => t.AssetType).Where(t => t.AssetType.Id == AssetTypeEnum.Server).ToList();
        //    return _context.Assets.ToList();
        //}

        //public IEnumerable<Asset> GetAllWorkstationAssets()
        //{
        //    var list = _context.Assets.Include(t => t.AssetType).Where(t => t.AssetType.Id == AssetTypeEnum.Workstation).ToList();
        //    return _context.Assets.ToList();
        //}

        public Asset GetAssetByName(string assetName)
        {
            return _context.Assets
                .Include(t => t.AssetType)
                //.Where(t => t.Name == tripName && t.UserName == username)
                .Where(t => t.Name == assetName)
                .FirstOrDefault();
        }

        public Asset GetAssetById(int assetId)
        {
            return _context.Assets
                .Include(t => t.AssetType)
                //.Where(t => t.Name == tripName && t.UserName == username)
                .Where(t => t.Id == assetId)
                .FirstOrDefault();
        }

        //public object GetAssetsByUsername(string name)
        //{
        //    return _context.Assets
        //        //.Where(t => t.UserName == name)
        //        .ToList();
        //}

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public int AddAsset(Asset asset)
        {
            _context.Assets.Add(asset);
            _context.Entry(asset.AssetType).State = EntityState.Detached;
            return _context.SaveChanges();
        }

        public int UpdateAsset(Asset asset)
        {
            _context.Assets.Update(asset);
            _context.Entry(asset.AssetType).State = EntityState.Detached;
            return _context.SaveChanges();
        }

        public int DeleteAsset(Asset asset)
        {
            _context.Assets.Remove(asset);
            return _context.SaveChanges();
        }
    }
}
