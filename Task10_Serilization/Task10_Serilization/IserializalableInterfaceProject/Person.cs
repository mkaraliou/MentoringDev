using System.Runtime.Serialization;

namespace IserializalableInterfaceProject
{
    [Serializable]
    public class Person : ISerializable
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person(SerializationInfo information, StreamingContext context)
        {
            Name = information.GetString("Kek");
            Age = information.GetInt32("Fek");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Kek", Name);
            info.AddValue("Fek", Age);
        }
    }
}