using Microsoft.Extensions.DependencyInjection;
using System;

namespace Startup.Api.Misc
{
    public delegate void ConfigureServices(IServiceCollection services);
    public delegate void ConfigureProvider(IServiceProvider provider);
}
