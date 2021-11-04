using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Startup.Api.Misc;
using System;

namespace Startup.Api
{
    public static class NetCoreApiApp
    {
        public static void Run(IStartupConfiguration startupConfiguration)
        {
            WebHost.CreateDefaultBuilder<Startup>(Environment.GetCommandLineArgs())
                   .ConfigureServices(services =>
                   {
                       services.AddSingleton(startupConfiguration);
                   })
                   .Build()
                   .Run();
        }
    }
}
