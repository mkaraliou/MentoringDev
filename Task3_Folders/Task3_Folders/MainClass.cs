namespace Task3_Folders
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                VerifyArgs(args);
                RunWithPredicate(args);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RunWithPredicate(string[] args)
        {
            var visitor = new FileSystemVisitor(args[0], x => !x.Contains(".txt"));
            visitor.Start += Start;
            visitor.Finish += Finish;
            visitor.DirectoryFound += DirectoryFound;
            visitor.FilteredDirectoryFound += FilteredDirectoryFound;
            visitor.FileFound += FileFound;
            visitor.FilteredFileFound += FilteredFilesFound;

            foreach (var value in visitor.GetFoldersFilesRecursively())
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
            if (e.Path.Contains("44"))
            {
                e.Skip = true;
            }
        }

        private static void FileFound(object sender, FolderFilesEventArgs e)
        {
            if (e.Path.Contains(".pptx"))
            {
                e.Skip = true;
            }

            if (e.Path.Contains("3.docx"))
            {
                e.Stop = true;
            }
        }

        private static void FilteredDirectoryFound(object sender, FolderFilesEventArgs e)
        {
            if (e.Path.Contains("Folder6"))
            {
                e.Skip = true;
            }

            if (e.Path.Contains("Folder6"))
            {
                e.Stop = true;
            }   
        }

        private static void FilteredFilesFound(object sender, FolderFilesEventArgs e)
        {
            if (e.Path.Contains(".xl"))
            {
                e.Skip = true;
            }

            if (e.Path.Contains(".xl"))
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
