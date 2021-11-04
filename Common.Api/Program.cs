using Auth.DataLayer;
using Auth.DataLayer.Entities;
using Common.Api.Contexts;
using Education.DataLayer;
using Education.DataLayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using Startup.Api;
using Startup.Api.Misc;

namespace Common.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NetCoreApiApp.Run(new StartupConfiguration(new[]
            {
                (typeof(AuthContext), typeof(IAuthEntity)),
                (typeof(EducationContext), typeof(IEducationEntity))
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
