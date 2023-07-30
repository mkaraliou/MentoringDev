using System.Runtime.Serialization;

namespace BinarySerilizationProject
{
    [Serializable]
    public class Department : ISerializable
    {
        public string DepartmentName { get; set; }

        public int DepartmentId { get; set; }

        public List<Employee> Employees { get; set; }

        public Department() 
        {

        }

        public Department(SerializationInfo info, StreamingContext context)
        {
            DepartmentName = info.GetString("Id");
            DepartmentId = info.GetInt32("Id");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", DepartmentName);
            info.AddValue("Id", DepartmentId);
        }
    }
}
