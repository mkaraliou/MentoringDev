namespace LibraryProject
{
    public class HelloHelper
    {
        public static string CreateHelloPhrase(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Incorrect args count.");
            }

            return $"{DateTime.Now:G} Hello, {username}!";
        }
    }
}