using System;

namespace Startup.Api.Misc
{
    public class StartupConfiguration : IStartupConfiguration
    {
        public StartupConfiguration((Type dbContextType, Type interfaceEntity)[] databaseCollection,
                                    ConfigureServices configureServices,
                                    ConfigureProvider configureProvider)
        {
            DatabaseCollection = new DatabaseCollection(databaseCollection);

            ConfigureServices = configureServices;
            ConfigureProvider = configureProvider;
        }

        public DatabaseCollection DatabaseCollection { get; }

        public ConfigureServices ConfigureServices { get; }
        public ConfigureProvider ConfigureProvider { get; }
    }
}
