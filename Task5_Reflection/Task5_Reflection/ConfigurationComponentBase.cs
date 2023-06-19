using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using Task5_Reflection.Attributes;

namespace Task5_Reflection
{
    public abstract class ConfigurationComponentBase
    {
        private const string FilePath = "C:\\Users\\Mikalai_Karaliou\\source\\repos\\Task5_Reflection\\Task5_Reflection\\file.txt";
        private const string AppConfigPath = "C:\\Users\\Mikalai_Karaliou\\source\\repos\\Task5_Reflection\\Task5_Reflection\\appsettings.json";
        private const char delemetr = '=';

        private Dictionary<string, string> _fileContent = new Dictionary<string, string>();
        private Dictionary<string, string> _configurationFileContent = new Dictionary<string, string>();

        public void SaveSettings()
        { 
            // project.SaveSettings() via reflection
            GetSettingsFromFile();
            GetSettingsFromConfig();

            Type type = GetType();
            var properties = type.GetProperties();

            foreach ( var property in properties )
            {
                SavePropertyToDictionary<ConfigurationManagerConfigurationItemAttribute>(property, _configurationFileContent);
                SavePropertyToDictionary<FileConfigurationItemAttribute>(property, _fileContent);
            }

            SavePropertyToFile();
            SavePropertyToConfigurationFile();
        }

        public void LoadSettings() 
        {
            GetSettingsFromFile();
            GetSettingsFromConfig();

            foreach (var property in GetType().GetProperties())
            {
                SetValueToProperty<ConfigurationManagerConfigurationItemAttribute>(property, _configurationFileContent);
                SetValueToProperty<FileConfigurationItemAttribute>(property, _fileContent);
            }
        }

        private void GetSettingsFromFile()
        {
            var fileContent = FileReader.Read(FilePath);

            fileContent = fileContent.Trim('\r', '\n');
            fileContent = fileContent.Replace(" ", string.Empty);

            foreach (var pair in fileContent.Split(Environment.NewLine))
            {
                var k = pair.Split(delemetr);

                _fileContent[k[0]] = k[1];
            }
        }

        private void GetSettingsFromConfig()
        {
            var configurationRoot = new ConfigurationBuilder().AddJsonFile(AppConfigPath).Build();

            var firstProvider = configurationRoot.Providers.First();

            var tempRoot = new ConfigurationRoot(new List<IConfigurationProvider>() { firstProvider });

            _configurationFileContent = tempRoot.AsEnumerable().ToDictionary(a => a.Key, a => a.Value);
        }

        private void SavePropertyToDictionary<T>(PropertyInfo property, Dictionary<string, string> content)
            where T : ConfigurationItemBaseAttribute
        {
            var attributes = property.GetCustomAttributes(true);

            if (attributes.Any(a => a is T))
            {
                var attribute = (T)attributes.First(a => a is T);

                content[attribute.SettingName] = property.GetValue(this).ToString();
            }

        }

        private void SavePropertyToConfigurationFile()
        {
            var jsonContent = JsonConvert.SerializeObject(_configurationFileContent);

            FileReader.Write(AppConfigPath, jsonContent);
        }

        private void SavePropertyToFile()
        {
            var pairList = new List<string>();

            foreach(var pair in _fileContent)
            {
                pairList.Add($"{pair.Key} {delemetr} {pair.Value}");
            }

            var contentToFile1 = string.Join(Environment.NewLine, pairList);
            FileReader.Write(FilePath, contentToFile1);
        }

        private void SetValueToProperty<T>(PropertyInfo property, Dictionary<string, string> content)
            where T : ConfigurationItemBaseAttribute
        {
            var attributes = property.GetCustomAttributes(true);

            if (attributes.Any(a => a is T))
            {
                var attribute = (T)attributes.First(a => a is T);

                if (content.ContainsKey(attribute.SettingName))
                {
                    SetValueToPropertyWithReflection(property, content[attribute.SettingName]);
                }
            }
        }

        private void SetValueToPropertyWithReflection(PropertyInfo property, string value)
        {
            if (property.PropertyType == typeof(string))
            {
                property.SetValue(this, value);
            }
            else
            {
                Type[] argTypes = { typeof(string) };
                var parseMethodInfo = property.PropertyType.GetMethod("Parse", argTypes);

                object[] parameters = new object[] { value };
                var s = parseMethodInfo.Invoke(null, parameters);

                property.SetValue(this, s);
            }
        }
    }
}
