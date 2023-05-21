namespace Task3_Folders
{
    public class FileSystemVisitor
    {
        private DirectoryInfo _currentDirectory;
        private Predicate<string> _predicate = (s) => true;
        private FolderFilesEventArgs _args = new FolderFilesEventArgs();

        public event EventHandler Start;

        public event EventHandler Finish;

        public event EventHandler<FolderFilesEventArgs> FileFound;

        public event EventHandler<FolderFilesEventArgs> DirectoryFound;

        public event EventHandler<FolderFilesEventArgs> FilteredFileFound;

        public event EventHandler<FolderFilesEventArgs> FilteredDirectoryFound;

        public FileSystemVisitor(string filePath) 
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException($"Filepath should not be null or empty.");
            }

            _currentDirectory = new DirectoryInfo(filePath);
        }

        public FileSystemVisitor(string filePath, Predicate<string> predicate) : this (filePath)
        {
            _predicate = predicate;
        }

        public IEnumerable<string> GetFoldersFilesRecursively()
        {
            Start?.Invoke(this, EventArgs.Empty);
            foreach(var k in GetFoldersFilesRecursively(_currentDirectory))
            {
                yield return k;
            }
            Finish?.Invoke(this, EventArgs.Empty);
        }

        private IEnumerable<string> GetFoldersFilesRecursively(DirectoryInfo directory)
        {
            var directories = directory.GetDirectories();
            foreach (var dir in directories)
            {
                if (_args.Stop)
                {
                    yield break;
                }

                var directoryPath = dir.Name;

                InvokeEvent(DirectoryFound, directoryPath);

                if (!_args.Skip && _predicate(directoryPath))
                {
                    InvokeEvent(FilteredDirectoryFound, directoryPath);

                    if (!_args.Skip)
                    {
                        yield return directoryPath;
                    }
                }

                foreach (var value in GetFoldersFilesRecursively(dir))
                {
                    yield return value;
                }
            }

            foreach (var f in GetFiles(directory))
            {
                yield return f;
            }
        }

        private IEnumerable<string> GetFiles(DirectoryInfo directory)
        {
            foreach (var f in directory.GetFiles())
            {
                if (_args.Stop)
                {
                    yield break;
                }

                var fileName = f.Name;

                if (fileName.Contains("3.docx"))
                {
                }

                InvokeEvent(FileFound, fileName);

                if (!_args.Skip && _predicate(fileName))
                {
                    InvokeEvent(FilteredFileFound, fileName);

                    if (!_args.Skip)
                    {
                        yield return fileName;
                    }
                }
            }
        }

        private void InvokeEvent(EventHandler<FolderFilesEventArgs> eventExample, string fullName)
        {
            var stop = _args.Stop;
            _args.Stop = false;
            _args.Skip = false;

            _args.Path = fullName;

            eventExample?.Invoke(this, _args);

            if (stop)
            {
                _args.Stop = true;
            }
        }
    }
}
