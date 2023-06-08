namespace Task5_Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FileConfigurationItemAttribute : ConfigurationItemBaseAttribute
    {
        public FileConfigurationItemAttribute(string settingsName) : base(settingsName)
        {
        }
    }
}
