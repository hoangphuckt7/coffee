﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Hubs
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
            return "";
        }

        public static string GetId(this ClaimsPrincipal user)
        {
            var x = user.HasClaim(x => x.Type == ClaimTypes.NameIdentifier);
            var idClaim = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (idClaim != null)
            {
                return idClaim.Value;
            }
            return "";
        }
    }
}
