using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementWebApp.Models
{
    public enum AssetTypeEnum
    {
        Application = 1,
        Component = 2,
        Database = 3,
        Server = 4,
        Workstation = 5        
    }
    public class AssetType
    {
        private AssetTypeEnum _id;
        public AssetTypeEnum Id
        {
            get => _id;
            set { _id = value; Description = _id.ToString(); }            
        }
        public string Description { get; set; }
    }
}
