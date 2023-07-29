using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerilizationProject
{
    public class BinaryDepartmentRepository
    {
        private string _filePath;
        private BinaryFormatter formatter = new ();

        public BinaryDepartmentRepository(string filePath)
        {
            _filePath = filePath;
        }

        public Department Deserialize()
        {
            // десериализация
            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                return (BinarySerilizationProject.Department)formatter.Deserialize(fs);
            }
        }

        public void Serialize(Department entity)
        {
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, entity);
            }
        }
    }
}
