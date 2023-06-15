using System.Reflection;
using System.Runtime.Loader;

namespace Task5_Reflection
{
    public abstract class ConfigurationComponentBase
    {
        private List<Type> _typesFromSaveSettingsHelper = new List<Type>();

        public ConfigurationComponentBase()
        {
            string path = "C:\\Users\\Mikalai_Karaliou\\Work\\MentoringDevelopment\\MentoringDev\\Task5_Reflection\\Task5_Reflection\\Plugins";

            foreach (var dllFile in Directory.GetFiles(path, "*.dll"))
            {
                var k = new AssemblyLoadContext("Name");
                var assembly = k.LoadFromAssemblyPath(dllFile);

                //var assembly = Assembly.Load(dllFile);

                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetInterfaces().Contains(typeof(ISaveSettingsHelper)))
                    {
                        _typesFromSaveSettingsHelper.Add(type);
                    }
                }
            }
        }

        public void SaveSettings()
        {
            foreach (var type in _typesFromSaveSettingsHelper)
            {
                var saveSettingsHelper = Activator.CreateInstance(type) as ISaveSettingsHelper;

                saveSettingsHelper.SaveSettings(this);
            }
        }

        public void LoadSettings()
        {
            foreach (var type in _typesFromSaveSettingsHelper)
            {
                var saveSettingsHelper = Activator.CreateInstance(type) as ISaveSettingsHelper;

                saveSettingsHelper.LoadSettings(this);
            }
        }
    }
}
