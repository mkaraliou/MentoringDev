using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace Task10_Serilization
{
    public class Program
    {
        private static string folder = "C:\\Users\\Mikalai_Karaliou\\Work\\MentoringDevelopment\\MentoringDev\\Task10_Serilization\\Task10_Serilization\\Files\\";

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

            // serialization
            string output = JsonConvert.SerializeObject(departmentJson);

            var fileHelperJson = new FileHelper(folder + "jsonfile.json");

            fileHelperJson.WriteToFile(output);

            // deserialization
            string inFileContent = fileHelperJson.ReadFromFile();
            JsonSerilizationProject.Department department = JsonConvert.DeserializeObject<JsonSerilizationProject.Department>(inFileContent);
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

            // передаем в конструктор тип класса Department
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlSerializationProject.Department));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(folder + "xmlFile.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, departmentXml);
            }

            XmlSerializationProject.Department? department = null;

            // десериализуем объект
            using (FileStream fs = new FileStream(folder + "xmlFile.xml", FileMode.OpenOrCreate))
            {
                department = xmlSerializer.Deserialize(fs) as XmlSerializationProject.Department;
            }
        }

        private static void ShowBinary()
        {
            var departmentBinary = new BinarySerilizationProject.Department()
            {
                DepartmentName = "BinaryD",
                Employees = new List<BinarySerilizationProject.Employee>()
                {
                    new BinarySerilizationProject.Employee() { EmpoyeeName = "BinaryE1" },
                    new BinarySerilizationProject.Employee() { EmpoyeeName = "BinaryE2" },
                    new BinarySerilizationProject.Employee() { EmpoyeeName = "BinaryE3" }
                }
            };

            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(folder + "binaryFile.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, departmentBinary);
            }

            BinarySerilizationProject.Department department = null;
            // десериализация
            using (FileStream fs = new FileStream(folder + "binaryFile.txt", FileMode.OpenOrCreate))
            {
                department = (BinarySerilizationProject.Department)formatter.Deserialize(fs);
            }
        }
    }
}