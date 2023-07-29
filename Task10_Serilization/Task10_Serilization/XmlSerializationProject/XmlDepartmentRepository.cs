using System.Xml.Serialization;

namespace XmlSerializationProject
{
    public class XmlDepartmentRepository
    {
        private string _filePath;
        private XmlSerializer xmlSerializer = new (typeof(Department));

        public XmlDepartmentRepository(string filePath)
        {
            _filePath = filePath;
        }

        public Department Deserialize()
        {
            // десериализуем объект
            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                return xmlSerializer.Deserialize(fs) as Department;
            }
        }

        public void Serialize(Department entity)
        {
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, entity);
            }
        }
    }
}
