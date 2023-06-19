namespace Task5_Reflection.Attributes
{
    public class ConfigurationItemBaseAttribute : Attribute
    {
        public string SettingName { get; set; }

        public ConfigurationItemBaseAttribute(string settingName) 
        {
            SettingName = settingName;
        }
    }
}
