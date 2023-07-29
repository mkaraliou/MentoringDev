using BaseSerializationProject;
using Newtonsoft.Json;

namespace JsonSerilizationProject
{
    // Fluent API - это тоже самое, как будто навешивать аттрибуты, но делаю это с помощью методов
    public class JsonDepartmentRepository : IRepository<Department>
    {
        private FileHelper fileHelper;

        public JsonDepartmentRepository(string filePath)
        {
            fileHelper = new FileHelper(filePath);
        }

        public Department Deserialize()
        {
            string inFileContent = fileHelper.ReadFromFile();
            return JsonConvert.DeserializeObject<JsonSerilizationProject.Department>(inFileContent);
        }

        public void Serialize(Department entity)
        {
            string output = JsonConvert.SerializeObject(entity);
            fileHelper.WriteToFile(output);
        }
    }
}
