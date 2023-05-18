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
                var directoryPath = dir.FullName;

                var directoryFoundEventArgs = new FolderFilesEventArgs()
                {
                    Path = directoryPath,
                };

                DirectoryFound?.Invoke(this, directoryFoundEventArgs);

                if (!directoryFoundEventArgs.Skip && _predicate(directoryPath))
                {
                    var filteredDirectoryFoundEventArgs = new FolderFilesEventArgs()
                    {
                        Path = directoryPath,
                    };

                    FilteredDirectoryFound?.Invoke(this, filteredDirectoryFoundEventArgs);
                    
                    if (!filteredDirectoryFoundEventArgs.Skip)
                    {
                        yield return directoryPath;
                    }
                    else
                    {
                        //Console.WriteLine($"Skip filtered found directory {directoryPath}");
                    }

                    if (filteredDirectoryFoundEventArgs.Stop)
                    {
                        //Console.WriteLine($"Stop after filtered fould directory {directoryPath}");

                        yield break;
                    }
                }
                else
                {
                    //Console.WriteLine($"Skip found directory {directoryPath}");
                }

                if (directoryFoundEventArgs.Stop)
                {
                    //Console.WriteLine($"Stop after fould directory {directoryPath}");

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
                    var filteredFilesFoundEventArgs = new FolderFilesEventArgs()
                    {
                        Path = fileName,
                    };

                    FilteredFileFound?.Invoke(this, filteredFilesFoundEventArgs);

                    if (!filteredFilesFoundEventArgs.Skip)
                    { 
                        yield return fileName;
                    }
                    else
                    {
                        //Console.WriteLine($"Skip filtered found file {fileName}");
                    }

                    if (filteredFilesFoundEventArgs.Stop)
                    {
                        //Console.WriteLine($"Stop after filtered fould file {fileName}");
                        yield break;
                    }
                }
                else
                {
                    //Console.WriteLine($"Skip found file {fileName}");
                }

                if (fileFoundEventArgs.Stop)
                {
                    //Console.WriteLine($"Stop after fould file {fileName}");

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
