using Auth.Shared.Enums;
using Auth.Shared.Misc;
using Auth.Shared.Services;
using Common.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Auth.Shared.Middlewares
{
    public class DefaultAuthenticationHandler : AuthenticationHandler<AuthenticationHandlerOptions>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ITokenService tokenService;
        private readonly IDateTimeManager dateTimeManager;

        public DefaultAuthenticationHandler(IOptionsMonitor<AuthenticationHandlerOptions> options,
                                            ILoggerFactory logger,
                                            UrlEncoder encoder,
                                            ISystemClock clock,
                                            IHttpContextAccessor httpContextAccessor,
                                            ITokenService tokenService,
                                            IDateTimeManager dateTimeManager)
            : base(options, logger, encoder, clock)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.tokenService = tokenService;
            this.dateTimeManager = dateTimeManager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var rawToken = (string)httpContextAccessor.HttpContext.Request.Headers["authorization"];

            if (String.IsNullOrEmpty(rawToken))
                return AuthenticateResult.Fail("Unauthorized");

            if (rawToken.StartsWith("Bearer "))
                rawToken = rawToken.Replace("Bearer ", string.Empty);

            var token = tokenService.GetTokenRepresentation(rawToken);

            var isTokenExpired = dateTimeManager.UtcNow > token.ValidTo;
            if (isTokenExpired)
                return AuthenticateResult.Fail("Unauthorized");

            var userId = token.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.UserId).Value;
            var personId = token.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.PersonId).Value;
            var roles = token.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Roles)
                .Value
                .Split(':');

            var claims = new[]
            {
                new Claim(JwtClaimTypes.UserId, userId),
                new Claim(JwtClaimTypes.PersonId, personId),
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new GenericPrincipal(identity, roles);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
