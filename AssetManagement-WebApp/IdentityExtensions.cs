using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebApp.ExtensionMethods
{
    public static class IdentityExtensions
    {
        public static string FullName(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                ClaimsIdentity claimsIdentity = user.Identity as ClaimsIdentity;
                foreach (var claim in claimsIdentity.Claims)
                {
                    if (claim.Type == "displayName")
                        return claim.Value;
                }
                return "";
            }
            else
                return "";
        }
    }
}
