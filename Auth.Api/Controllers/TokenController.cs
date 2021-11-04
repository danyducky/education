using Auth.Api.Contexts;
using Auth.Api.Static;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers
{
    [ApiController]
    public class TokenController : Controller
    {
        private readonly AppRequestContext context;

        public TokenController(AppRequestContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Обновление токена
        /// </summary>
        /// <returns></returns>
        [HttpPost("token/refresh")]
        [Produces(typeof(string))]
        public IActionResult Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var pack = context.TryRefreshToken(refreshToken, GetIpAddress());

            HttpContext.Response.Cookies.Append("refreshToken", pack.RefreshToken.Token, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok(pack.AccessToken);
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
