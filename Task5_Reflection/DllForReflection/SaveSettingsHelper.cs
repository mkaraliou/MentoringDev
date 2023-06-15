using AttributesProject;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Reflection;
using Task5_Reflection;

namespace DllForReflection
{
    public class SaveSettingsHelper : ISaveSettingsHelper
    {
        private const string FilePath = "C:\\Users\\Mikalai_Karaliou\\Work\\MentoringDevelopment\\MentoringDev\\Task5_Reflection\\Task5_Reflection\\file.txt";
        private const string AppConfigPath = "C:\\Users\\Mikalai_Karaliou\\Work\\MentoringDevelopment\\MentoringDev\\Task5_Reflection\\Task5_Reflection\\appsettings.json";
        private const char delemetr = '=';

        private Dictionary<string, string> _fileContent = new Dictionary<string, string>();
        private ConfigurationRoot _appSettingConfiguration;

        private object _objectExample;

        public void SaveSettings(object o)
        {
            _objectExample = o;

            GetSettingsFromFile();
            GetSettingsFromConfig();

            Type type = _objectExample.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                SaveProperty(property);
            }

            SavePropertyToFile();
            SavePropertyToConfigurationFile();
        }

        public void LoadSettings(object o)
        {
            _objectExample = o;

            GetSettingsFromFile();
            GetSettingsFromConfig();

            foreach (var property in _objectExample.GetType().GetProperties())
            {
                SetValueToProperty(property);
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

            _appSettingConfiguration = new ConfigurationRoot(new List<IConfigurationProvider>() { firstProvider });
        }

        private void SaveProperty(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(true);

            if (attributes.Any(a => a is ConfigurationManagerConfigurationItemAttribute))
            {
                var attribute = (ConfigurationManagerConfigurationItemAttribute)attributes.First(a => a is ConfigurationManagerConfigurationItemAttribute);

                _appSettingConfiguration[attribute.SettingName] = property.GetValue(_objectExample).ToString();
            }

            if (attributes.Any(a => a is FileConfigurationItemAttribute))
            {
                var attribute = (FileConfigurationItemAttribute)attributes.First(a => a is FileConfigurationItemAttribute);

                _fileContent[attribute.SettingName] = property.GetValue(_objectExample).ToString();
            }
        }

        private void SavePropertyToConfigurationFile()
        {
            var k = _appSettingConfiguration.AsEnumerable().ToDictionary(a => a.Key, a => a.Value);
            var jsonContent = JsonConvert.SerializeObject(_appSettingConfiguration.AsEnumerable().ToDictionary(a => a.Key, a => a.Value));

            FileReader.Write(AppConfigPath, jsonContent);
        }

        private void SavePropertyToFile()
        {
            var pairList = new List<string>();

            foreach (var pair in _fileContent)
            {
                pairList.Add($"{pair.Key} {delemetr} {pair.Value}");
            }

            var contentToFile1 = string.Join(Environment.NewLine, pairList);
            FileReader.Write(FilePath, contentToFile1);
        }

        private void SetValueToProperty(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(true);

            if (attributes.Any(a => a is ConfigurationManagerConfigurationItemAttribute))
            {
                var attribute = (ConfigurationManagerConfigurationItemAttribute)attributes.First(a => a is ConfigurationManagerConfigurationItemAttribute);

                var valueFromAppseetings = _appSettingConfiguration[attribute.SettingName];

                if (valueFromAppseetings != null)
                {
                    SetValueToPropertyWithReflection(property, valueFromAppseetings);
                }
            }

            if (attributes.Any(a => a is FileConfigurationItemAttribute))
            {
                var attribute = (FileConfigurationItemAttribute)attributes.First(a => a is FileConfigurationItemAttribute);

                if (_fileContent.ContainsKey(attribute.SettingName))
                {
                    SetValueToPropertyWithReflection(property, _fileContent[attribute.SettingName]);
                }
            }
        }

        private void SetValueToPropertyWithReflection(PropertyInfo property, string value)
        {
            if (property.PropertyType == typeof(string))
            {
                property.SetValue(_objectExample, value);
            }
            else
            {
                Type[] argTypes = { typeof(string) };
                var parseMethodInfo = property.PropertyType.GetMethod("Parse", argTypes);

                object[] parameters = new object[] { value };
                var s = parseMethodInfo.Invoke(null, parameters);

                property.SetValue(_objectExample, s);
            }
        }
    }

}