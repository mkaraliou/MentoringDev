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
            //ShowJsonSerialization();
            ShowXML();
            //ShowBinary();
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

            var department1 = repository.DeepCloning(department);
            var department2 = department;

            var k = department1 == department2;
            var k1 = department1.Equals(department2);

            department1.DepartmentName = "Mik";
        }

        private static void ShowXML()
        {
            var departmentXml = new XmlSerializationProject.Department()
            {
                DepartmentName = "XmlDep",
                Employees = new List<XmlSerializationProject.Employee>()
                {
                    new XmlSerializationProject.Employee() { EmpoyeeName = "XmlE10" },
                    new XmlSerializationProject.Employee() { EmpoyeeName = "XmlE11" },
                    new XmlSerializationProject.Employee() { EmpoyeeName = "XmlE12" }
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