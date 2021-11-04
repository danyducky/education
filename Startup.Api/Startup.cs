using Auth.Shared.Middlewares;
using Auth.Shared.Misc;
using Common.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Startup.Api.Configs;
using Startup.Api.Extensions;
using Startup.Api.Misc;
using System.Reflection;

namespace Startup.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IStartupConfiguration startupConfiguration;

        public Startup(IConfiguration configuration, IStartupConfiguration startupConfiguration)
        {
            this.configuration = configuration;
            this.startupConfiguration = startupConfiguration;
        }

        private IConfigurationSection Config { get => configuration.GetSection("Config"); }
        private IConfigurationSection Redis { get => configuration.GetSection("Redis"); }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddApplicationPart(Assembly.GetEntryAssembly());

            services.AddApplicationDefaults(configuration, startupConfiguration.DatabaseCollection);

            services.AddDefaultServices();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = $"{Redis["host"]}:{Redis["port"]}";
            });

            services.AddAuthentication(AuthenticationDefaults.EduScheme)
                    .AddJwtBearer(x => x.Configure(Config))
                    .AddScheme<AuthenticationHandlerOptions, DefaultAuthenticationHandler>(AuthenticationDefaults.EduScheme, null);
            //.AddCookie(options => options.Cookie.SameSite = SameSiteMode.None);
            // AddCookie SameSiteMode.None: for cross-site cookie support

            startupConfiguration.ConfigureServices(services);

            services.AddCors();

            services.AddSwaggerGen(SwaggerConfiguration.ConfigureOptions);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            startupConfiguration.ConfigureProvider(app.ApplicationServices);

            app.UseSwagger();
            app.UseSwaggerUI(SwaggerConfiguration.ConfigureUIOptions);

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
               c.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()
               );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCustomExceptionMiddleware();
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
