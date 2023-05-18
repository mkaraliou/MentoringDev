namespace Task3_Folders
{
    public class FolderFilesEventArgs : EventArgs
    {
        public string Path { get; set; }

        public bool Skip { get; set; }

        public bool Stop { get; set; }
    }
}
