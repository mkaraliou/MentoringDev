namespace Task3_Folders
{
    public class FileSystemVisitor
    {
        private DirectoryInfo _currentDirectory;
        private Predicate<string> _predicate = (s) => true;

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
                var directoryFoundEventArgs = new FolderFilesEventArgs()
                {
                    Path = dir.FullName,
                };

                DirectoryFound?.Invoke(this, directoryFoundEventArgs);

                if (!directoryFoundEventArgs.Skip && _predicate(dir.FullName))
                {
                    yield return dir.FullName;
                }

                if (directoryFoundEventArgs.Stop)
                {
                    yield break;
                }

                foreach (var value in GetFoldersFilesRecursively(dir))
                {
                    if (_predicate(value))
                    {
                        yield return value;
                    }
                }
            }

            foreach (var f in directory.GetFiles())
            {
                var fileName = f.FullName;

                var fileFoundEventArgs = new FolderFilesEventArgs()
                {
                    Path = fileName,
                };

                FileFound?.Invoke(this, fileFoundEventArgs);

                if (!fileFoundEventArgs.Skip && _predicate(fileName))
                {
                    yield return fileName;
                }

                if (fileFoundEventArgs.Stop)
                {
                    yield break;
                }
            }
        }

        //private IEnumerable<string> Some(EventHandler<FolderFilesEventArgs> eventExample, string fullName)
        //{
        //    var eventArgs = new FolderFilesEventArgs()
        //    {
        //        Path = fullName,
        //    };

        //    eventExample?.Invoke(this, eventArgs);

        //    if (!eventArgs.Skip && _predicate(fullName))
        //    {
        //        yield return fullName;
        //    }

        //    if (eventArgs.Stop)
        //    {
        //        yield break;
        //    }
        //}
    }
}
