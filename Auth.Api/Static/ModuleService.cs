using Auth.Api.Contexts;
using Auth.Api.Models.Module;
using Auth.DataLayer;
using Auth.DataLayer.Entities;
using Auth.Shared.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Auth.Api.Static
{
    public static class ModuleService
    {
        public static IList<ModuleItemModel> GetAvailableModules(this AppRequestContext context)
        {
            return context.Get<ModuleBindings>()
                .ByRoleIds(context.GetCurrentUser().RoleIds)
                .Distinct()
                .Include(x => x.Module)
                .Select(x =>
                    new ModuleItemModel(x.Module.Id, x.Module.Caption, x.Module.ShortCaption, x.Module.Route)
                    )
                .ToList();
        }
    }
}
