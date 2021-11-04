using Common.Magic;

namespace Common.Services
{
    public interface IConfig
    {
        T GetValue<T>(string key);
        void AlterValue(string key, string value);
    }

    public static class IConfigExtensions
    {
        public static T GetConfigValue<T>(this IHave<IConfig> context, string key) 
            => context.Entity.GetValue<T>(key);

        public static void AlterConfigValue(this IHave<IConfig> context, string key, string value) 
            => context.Entity.AlterValue(key, value);
    }
}
