namespace LibraryProject
{
    public class HelloHelper
    {
        public static string CreateHelloPhrase(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                return $"{DateTime.Now:G} Hello, {username}!";
            }
            else
            {
                throw new ArgumentException("Incorrect args count.");
            }
        }
    }
}