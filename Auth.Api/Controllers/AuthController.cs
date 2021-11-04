using Auth.Api.Contexts;
using Auth.Api.Models.Auth;
using Auth.Api.Static;
using Common.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Auth.Api.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly AppRequestContext context;

        public AuthController(AppRequestContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("auth/login")]
        [Produces(typeof(string))]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = context.TryLogin(model, GetIpAddress(), ModelState);
            if (result.IsValid)
            {
                HttpContext.Response.Cookies.Append("refreshToken", result.Pack.RefreshToken.Token, new CookieOptions
                {
                    HttpOnly = true
                });
                return Ok(result.Pack.AccessToken);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Разлогиниться
        /// </summary>
        /// <returns></returns>
        [HttpPost("auth/logout")]
        public IActionResult Logout()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            context.ForgetToken(refreshToken);

            HttpContext.Response.Cookies.Delete("refreshToken");
            return Ok();
        }

        private string GetIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
