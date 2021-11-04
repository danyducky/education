using Auth.Api.Contexts;
using Auth.Api.Models.Register;
using Auth.Api.Static;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Auth.Api.Controllers
{
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly AppRequestContext context;

        public RegisterController(AppRequestContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [Produces(typeof(Guid))]
        public IActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid || !context.Validate(model, ModelState))
                return BadRequest(ModelState);

            var userId = context.RegisterAndSave(model);

            return Ok(userId);
        }
    }
}
