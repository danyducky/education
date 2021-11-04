using Auth.Api.Contexts;
using Auth.DataLayer;
using Auth.DataLayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using Startup.Api;
using Startup.Api.Misc;

namespace Auth.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NetCoreApiApp.Run(new StartupConfiguration(new[]
            {
                (typeof(AuthContext), typeof(IAuthEntity))
            },
            (services) =>
            {
                services.AddScoped<AppRequestContext, AppRequestContext>();
            },
            (provider) =>
            {

            })
            );
        }
    }
}
