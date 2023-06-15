namespace AttributesProject
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationManagerConfigurationItemAttribute : ConfigurationItemBaseAttribute
    {
        public ConfigurationManagerConfigurationItemAttribute(string settingsName) : base(settingsName)
        {
        }
    }
}
