using Microsoft.EntityFrameworkCore;
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

        public AssetRepository(AssetContext context)
        {
            _context = context;
        }


        public IEnumerable<Asset> GetAllAssets()
        {
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
    }
}
