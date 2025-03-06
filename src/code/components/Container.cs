namespace RayGUI_cs
{
    /// <summary>Container component of the library.</summary>
    public class DropZone : Component
    {
        /// <summary>The abosulte file path for the output directory.</summary>
        public string OutputFilePath;

        /// <summary>Acceptable file type when file is dropped.</summary>
        public string ExtensionFile;

        /// <summary>Last dropped file.</summary>
        public string LastFile;

        /// <summary>Paths of the container's files.</summary>
        private readonly List<string> Files;

        /// <summary>Initializes a new instance of <see cref="Container"/>.</summary>
        /// <param name="x">X Position of the container</param>
        /// <param name="y">Y Position of the container</param>
        /// <param name="width">Width of the container</param>
        /// <param name="height">Height of the container</param>
        public DropZone(int x, int y, int width, int height) : base(x, y, width, height)
        {
            ExtensionFile = "";
            Files = new List<string>() { "" };
            OutputFilePath = "";
            LastFile = "";
        }

        /// <summary>Adds a file to the list of the container.</summary>
        /// <param name="file">File to add</param>
        public void AddFile(string file)
        {
            Files.Add(file);
        }

        /// <summary>Deletes a file from the list of the container.</summary>
        /// <param name="index">File to remove</param>
        public void DeleteFile(int index)
        {
            Files.RemoveAt(index);  
        }

        /// <summary>Returns a file from the list of the container.</summary>
        /// <param name="index">Index of the file.</param>
        /// <returns>The requested file.</returns>
        public string GetFile(int index)
        {
            return Files[index];
        }

        /// <summary>Returns the latest file added to the list of the container.</summary>
        /// <returns>The requested file.</returns>
        public string GetLastFile()
        {
            return Files.Last();
        }

        /// <summary>Clears the list of files of the container.</summary>
        public void ClearFiles()
        {
            Files.Clear();
            Files.Add("");
        }

        /// <summary>Checks if a file exists in the list of the container.</summary>
        /// <param name="file">File to search for</param>
        /// <returns>Returns <see langword="true"/> if the file exists. <see langword="false"/> otherwise.</returns>
        public bool Contains(string file)
        {
            return Files.Contains(file);
        }
    }
}