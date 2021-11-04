using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using Startup.Api.Misc;
using System;

namespace Startup.Api.Extensions
{
    internal static class AppServicesExtensions
    {
        internal static void AddApplicationDefaults(this IServiceCollection services, IConfiguration configuration, DatabaseCollection collection)
        {
            foreach (DatabaseCollectionItem item in collection)
            {
                var connectionString = configuration.GetConnectionString(item.DbContextType.Name);
                // Adding db context providers
                typeof(EntityFrameworkServiceCollectionExtensions)
                    .GetMethod("AddDbContext", 1, new Type[] { typeof(IServiceCollection), typeof(Action<DbContextOptionsBuilder>), typeof(ServiceLifetime), typeof(ServiceLifetime) })
                    .MakeGenericMethod(item.DbContextType)
                    .Invoke(services, new object[] { services, new Action<DbContextOptionsBuilder>(options => options.UseNpgsql(connectionString)), ServiceLifetime.Scoped, null });
                // Adding db context factories
                typeof(EntityFrameworkServiceCollectionExtensions)
                    .GetMethod("AddDbContextFactory", 1, new Type[] { typeof(IServiceCollection), typeof(Action<DbContextOptionsBuilder>), typeof(ServiceLifetime) })
                    .MakeGenericMethod(item.DbContextType)
                    .Invoke(services, new object[] { services, new Action<DbContextOptionsBuilder>(options => options.UseNpgsql(connectionString)), null })
                    ;

                services.Scan(scan => scan.FromAssemblies(item.DbContextType.Assembly)
                                          .AddClasses(x => x.Where(type => !type.IsAbstract && !type.IsSealed && !type.IsNested
                                                                        && (type.Name.EndsWith("Factory")
                                                                        || type.Name.EndsWith("Repository"))))
                                          .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                                          .AsMatchingInterface()
                                          .WithScopedLifetime());
            }

            services.Scan(scan => scan.FromEntryAssembly()
                                      .AddClasses(x => x.Where(type => !type.IsAbstract && !type.IsSealed && !type.IsNested
                                                                    && (type.Name.EndsWith("ModelBuilder")
                                                                    || type.Name.EndsWith("FormHandler")
                                                                    || type.Name.EndsWith("Validator"))))
                                      .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                                      .AsMatchingInterface()
                                      .WithScopedLifetime());
        }
    }
}
