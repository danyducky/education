using Auth.Api.Contexts;
using Auth.Api.Models.Module;
using Auth.Api.Static;
using Common.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Auth.Api.Controllers
{
    [BeAuthorized]
    [ApiController]
    public class ModuleController : Controller
    {
        private readonly AppRequestContext context;

        public ModuleController(AppRequestContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Получение списка доступных модулей
        /// </summary>
        /// <returns></returns>
        [HttpGet("module/available")]
        [Produces(typeof(IList<ModuleItemModel>))]
        public IActionResult GetAvailable()
        {
            var modules = context.GetAvailableModules();
            return Ok(modules);
        }
    }
}
