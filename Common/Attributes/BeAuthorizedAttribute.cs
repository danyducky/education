using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Common.Attributes
{
    public class BeAuthorizedAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] roles;

        public BeAuthorizedAttribute(params string[] roles)
        {
            this.roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (roles.Length > 0)
            {
                var hasOneOfRoles = roles.Any(role => user.IsInRole(role));
                if (!hasOneOfRoles)
                {
                    context.Result = new StatusCodeResult(403);
                    return;
                }
            }
        }
    }
}
