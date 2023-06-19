namespace Task5_Reflection
{
    public class MainClass
    {
        public static void Main()
        {
            Student student = new Student();

            student.SaveSettings();

            student.Name = "Mik";
            student.Age = 30;
            student.SomeTimeSpan = TimeSpan.FromSeconds(1);
            student.Rating = 10.0f;

            student.LoadSettings();
        }
    }
}
