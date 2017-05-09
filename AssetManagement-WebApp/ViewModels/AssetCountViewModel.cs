using AssetManagementWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebApp.ViewModels
{
    public class AssetCountViewModel
    {
        public AssetType AssetType { get; set; }
        public int Quantity { get; set; }
    }
}
