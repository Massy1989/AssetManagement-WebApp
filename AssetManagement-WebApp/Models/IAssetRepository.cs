using System.Collections.Generic;

namespace AssetManagementWebApp.Models
{
    public interface IAssetRepository
    {
        IEnumerable<Asset> GetAllAssets();
    }
}