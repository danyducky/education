using Auth.Api.Contexts;
using Auth.Api.Models.Shared;
using Auth.Api.Static;
using Common.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers
{
    [ApiController]
    [BeAuthorized]
    public class ProfileController : Controller
    {
        private readonly AppRequestContext context;

        public ProfileController(AppRequestContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Информация о текущем пользователе
        /// </summary>
        /// <returns></returns>
        [HttpGet("profile/getme")]
        [Produces(typeof(UserModel))]
        public IActionResult GetMe()
        {
            var model = context.GetMe();
            return Ok(model);
        }
    }
}