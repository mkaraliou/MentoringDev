using Task5_Reflection.Attributes;

namespace Task5_Reflection
{
    public class Student : ConfigurationComponentBase
    {
        [ConfigurationManagerConfigurationItem("Name")]
        public string Name { get; set; } = "Velma";

        [FileConfigurationItem("Age")]
        public int Age { get; set; } = 23;

        [ConfigurationManagerConfigurationItem("StudentRating")]
        public float Rating { get; set; } = 95.90f;

        [FileConfigurationItem("TimeSpan")]
        [ConfigurationManagerConfigurationItem("SomeTimeSpan")]
        public TimeSpan SomeTimeSpan { get; set; } = TimeSpan.FromSeconds(1000);
    }
}
