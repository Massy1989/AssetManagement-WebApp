using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagementWebApp.Models
{
    public interface IAssetRepository
    {
        IEnumerable<Asset> GetAllAssets();

        IEnumerable<AssetCount> GetAllAssetCounts();

        Asset GetAssetByName(string assetName, string username);

        int AddAsset(Asset asset);

        Task<bool> SaveChangesAsync();
        object GetAssetsByUsername(string name);
    }
}