using System.Text;

namespace Task10_Serilization
{
    public class FileHelper
    {
        public string FilePath { get; set; }

        public FileHelper(string filePath) 
        {
            FilePath = filePath;
        }

        public string ReadFromFile()
        {
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(FilePath);
            //Read the first line of text
            var line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                sb.AppendLine(line);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();

            return sb.ToString();
        }

        public void WriteToFile(string content)
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter(FilePath);
            //Write a line of text
            sw.WriteLine(content);
            //Close the file
            sw.Close();
        }
    }
}
