namespace Startup.Api.Misc
{
    public interface IStartupConfiguration
    {
        DatabaseCollection DatabaseCollection { get; }
        ConfigureServices ConfigureServices { get; }
        ConfigureProvider ConfigureProvider { get; }
    }
}
