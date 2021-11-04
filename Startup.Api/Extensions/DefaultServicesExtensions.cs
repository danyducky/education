using Auth.Shared.Services;
using Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Startup.Api.Extensions
{
    internal static class DefaultServicesExtensions
    {
        internal static void AddDefaultServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddSingleton<ICacheService, CacheService>()
                    ;

            services.AddSingleton<IConfig, Config>()
                    .AddSingleton<IDateTimeManager, DateTimeManager>()
                    .AddSingleton<IDataCryptor, DataCryptor>()
                    .AddSingleton<IDataHasher, DataHasher>()
                    ;

            services.AddSingleton<ITokenService, TokenService>();

            services.AddScoped<ICurrentUserProvider, CurrentUserProvider>()
                    ;
        }
    }
}
