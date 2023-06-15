namespace AttributesProject
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FileConfigurationItemAttribute : ConfigurationItemBaseAttribute
    {
        public FileConfigurationItemAttribute(string settingsName) : base(settingsName)
        {
        }
    }
}
