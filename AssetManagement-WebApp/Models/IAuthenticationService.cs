using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebApp.Models
{
    public interface IAuthenticationService
    {
        AppUser Login(string userename, string password);
    }
}
