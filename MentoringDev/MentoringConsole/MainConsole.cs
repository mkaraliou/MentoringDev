using LibraryProject;

namespace MentoringConsole
{
    public class MainConsole
    {
        public static void Main(string[] args)
        {
            VerifyArgs(args);
            Console.WriteLine(HelloHelper.CreateHelloPhrase(args[0]));
        }

        private static void VerifyArgs(string[] args)
        {
            if (!(args.Count() == 1))
            {
                throw new ArgumentException("Incorrect args count");
            }
        }
    }
}
