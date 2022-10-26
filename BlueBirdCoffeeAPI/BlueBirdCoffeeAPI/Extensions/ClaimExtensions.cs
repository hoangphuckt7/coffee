using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BlueBirdCoffeeAPI
{
    public static class ClaimExtensions
    {
        public static string GetRole(this ClaimsPrincipal user)
        {
            var x = user.HasClaim(x => x.Type == ClaimTypes.Role);
            var idClaim = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
            if (idClaim != null)
            {
                return idClaim.Value;
            }
            throw new Exception("Invalid token");
        }

        public static string GetId(this ClaimsPrincipal user)
        {
            var x = user.HasClaim(x => x.Type == ClaimTypes.NameIdentifier);
            var idClaim = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (idClaim != null)
            {
                return idClaim.Value;
            }
            throw new Exception("Invalid token");
        }
    }
}
