using JsonSerilizationProject;
using XmlSerializationProject;
using BinarySerilizationProject;

namespace Task10_Serilization
{
    public class Program
    {
        private const string folder = "C:\\Users\\Mikalai_Karaliou\\Work\\MentoringDevelopment\\MentoringDev\\Task10_Serilization\\Task10_Serilization\\Files\\";
        private const string jsonPath = "jsonfile.json";
        private const string xmlPath = "xmlFile.xml";
        private const string binaryPath = "binaryFile.txt";

        public static void Main()
        {
            ShowJsonSerialization();
            ShowXML();
            ShowBinary();
        }

        private static void ShowJsonSerialization()
        {
            var departmentJson = new JsonSerilizationProject.Department()
            {
                DepartmentName = "JsonD",
                Employees = new List<JsonSerilizationProject.Employee>()
                {
                    new JsonSerilizationProject.Employee() { EmpoyeeName = "JsonE4" },
                    new JsonSerilizationProject.Employee() { EmpoyeeName = "JsonE5" },
                    new JsonSerilizationProject.Employee() { EmpoyeeName = "JsonE6" }
                }
            };

            var repository = new JsonDepartmentRepository(folder + jsonPath);

            repository.Serialize(departmentJson);

            var department = repository.Deserialize();
        }

        private static void ShowXML()
        {
            var departmentXml = new XmlSerializationProject.Department()
            {
                DepartmentName = "XmlD",
                Employees = new List<XmlSerializationProject.Employee>()
                {
                    new XmlSerializationProject.Employee() { EmpoyeeName = "XmlE6" },
                    new XmlSerializationProject.Employee() { EmpoyeeName = "XmlE7" },
                    new XmlSerializationProject.Employee() { EmpoyeeName = "XmlE8" }
                }
            };

            var repository = new XmlDepartmentRepository(folder + xmlPath);

            repository.Serialize(departmentXml);

            var department = repository.Deserialize();
        }

        private static void ShowBinary()
        {
            var departmentBinary = new BinarySerilizationProject.Department()
            {
                DepartmentId = 1000,
                DepartmentName = "BinaryD",
                Employees = new List<BinarySerilizationProject.Employee>()
                {
                    new BinarySerilizationProject.Employee() { EmpoyeeName = "BinaryE1" },
                    new BinarySerilizationProject.Employee() { EmpoyeeName = "BinaryE2" },
                    new BinarySerilizationProject.Employee() { EmpoyeeName = "BinaryE3" }
                }
            };

            var repository = new BinaryDepartmentRepository(folder + binaryPath);

            repository.Serialize(departmentBinary);

            var department = repository.Deserialize();
        }
    }
}