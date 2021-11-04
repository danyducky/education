using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Common.Services
{
    public class Config : IConfig
    {
        private readonly IConfiguration configuration;

        private IConfigurationSection Section { get => configuration.GetSection("Config"); }

        public Config(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public T GetValue<T>(string key)
            => Section.GetSection(key).Value == null 
                ? default 
                : (T)Convert.ChangeType(Section.GetSection(key).Value, typeof(T));

        public void AlterValue(string key, string value)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "appsettings.json");
            var json = File.ReadAllText(filePath);

            dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            obj["Config"][key] = value;

            var result = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(filePath, result);
        }
    }
}
