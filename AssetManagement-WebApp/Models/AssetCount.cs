using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementWebApp.Models
{
    public class AssetCount
    {
        public AssetType AssetType { get; set; }
        public int Quantity { get; set; }
    }
}
