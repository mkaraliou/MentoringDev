namespace Task3_Folders
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                //VerifyArgs(args);
                //RunWithoutPredicate(args);
                RunWithPredicate(args);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RunWithoutPredicate(string[] args)
        {
            var visitor = new FileSystemVisitor(args[0]);

            var collection = visitor.GetFoldersFilesRecursively();

            foreach (var value in collection)
            {
                Console.WriteLine(value);
            }
        }

        private static void RunWithPredicate(string[] args)
        {
            var filePath = "C:\\Users\\Mikalai_Karaliou\\Work\\MentoringDevelopment\\Task3_Folders\\TestProject1\\Folder1";
            var visitor = new FileSystemVisitor(filePath); //x => x.Contains("F"));
            visitor.Start += Start;
            visitor.Finish += Finish;
            visitor.FileFound += FileFound;
            visitor.DirectoryFound += DirectoryFound;

            var collection = visitor.GetFoldersFilesRecursively();

            foreach (var value in collection)
            {
                Console.WriteLine(value);
            }
        }

        private static void VerifyArgs(string[] args)
        {
            if (!(args.Count() == 1))
            {
                throw new ArgumentException("Incorrect args count");
            }
        }

        private static void DirectoryFound(object sender, FolderFilesEventArgs e)
        {
            //if (e.Path.Contains("44"))
            //{
            //    e.Skip = true;
            //}

            //if (e.Path.Contains("44"))
            //{
            //    e.Stop = true;
            //}
        }

        private static void FileFound(object sender, FolderFilesEventArgs e)
        {
            if (e.Path.Contains(".txt"))
            {
                e.Skip = true;
            }

            if (e.Path.Contains("3.docx"))
            {
                e.Stop = true;
            }
        }

        private static void Start(object sender, EventArgs e)
        {
            Console.WriteLine("Start recursive method.");
        }

        private static void Finish(object sender, EventArgs e)
        {
            Console.WriteLine("Finish.");
        }
    }
}
