using System.Text;

namespace DllForReflection
{
    public static class FileReader
    {
        public static string Read(string path)
        {
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);

                return Encoding.Default.GetString(buffer);
            }
        }

        public static void Write(string path, string content)
        {
            File.WriteAllText(path, content);

            //using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            //{
            //    byte[] buffer = Encoding.Default.GetBytes(content);

            //    fstream.Write(buffer, 0, buffer.Length);
            //}
        }
    }
}
