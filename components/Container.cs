using Raylib_cs;

namespace RayGUI_cs
{
    /// <summary>
    /// Container type system
    /// </summary>
    public enum ContainerType
    {
        Custom = 0,
        FileDropper
    }
    /// <summary>
    /// 2-Dimensional container
    /// </summary>
    public class Container : Component
    {
        /// <summary>
        /// Background color of the container
        /// </summary>
        private Color color;
        /// <summary>
        /// Border color of the container
        /// </summary>
        private Color borderColor;
        /// <summary>
        /// Type of the container
        /// </summary>
        private ContainerType type;
        /// <summary>
        /// The file path for the output directory
        /// </summary>
        private string? outputFilePath;
        /// <summary>
        /// Acceptable file types (works only for the File Dropper type)
        /// </summary>
        private string? extensionFile;
        /// <summary>
        /// Paths of the container's files
        /// </summary>
        private List<string> files;
        /// <summary>
        /// The last added file
        /// </summary>
        private string lastFile;
        /// <summary>
        /// Background color for the container
        /// </summary>
        public Color Color { get { return color; } set { color = value; } }
        /// <summary>
        /// Border color for the container
        /// </summary>
        public Color BorderColor { get { return borderColor; } set { borderColor = value; } }
        /// <summary>
        /// Extension file filter
        /// </summary>
        public string? ExtensionFile { get { return extensionFile; } set { extensionFile = value; } }
        /// <summary>
        /// Output folder for dropped files
        /// </summary>
        public string? OutputFilePath { get { return outputFilePath; } set { outputFilePath = value; } }
        /// <summary>
        /// The last added file
        /// </summary>
        public string LastFile { get { return lastFile; } set { lastFile = value; } }
        /// <summary>
        /// Container type
        /// </summary>
        public ContainerType Type { get { return type; } set { type = value; } }
        /// <summary>
        /// Container constructor
        /// </summary>
        /// <param name="x">Container X position</param>
        /// <param name="y">Container Y position</param>
        /// <param name="width">Container width</param>
        /// <param name="height">Container height</param>
        /// <param name="color">Container main color</param>
        /// <param name="borderColor">Container second color</param>
        public Container(int x, int y, int width, int height, Color color, Color borderColor) : base(x, y, width, height)
        {
            // Color assignment
            Color = color;
            BorderColor = borderColor;
            this.Tag = "";

            ExtensionFile = "";
            files = new List<string>();
            files.Add("");
            Type = ContainerType.Custom;
            OutputFilePath = "";
            lastFile = "";
        }
        /// <summary>
        /// Container constructor
        /// </summary>
        /// <param name="x">Container X position</param>
        /// <param name="y">Container Y position</param>
        /// <param name="width">Container width</param>
        /// <param name="height">Container height</param>
        /// <param name="color">Container main color</param>
        /// <param name="borderColor">Container second color</param>
        /// <param name="tag">Container tag</param>
        public Container(int x, int y, int width, int height, Color color, Color borderColor, string tag) : base(x, y, width, height, tag)
        {
            // Color assignment
            Color = color;
            BorderColor = borderColor;

            ExtensionFile = "";
            files = new List<string>();
            files.Add("");
            Type = ContainerType.Custom;
            OutputFilePath = "";
            lastFile = "";
        }
        /// <summary>
        /// Add a file to the list of the container
        /// </summary>
        /// <param name="file">File to add</param>
        public void AddFile(string file)
        {
            files.Add(file);
        }
        /// <summary>
        /// Delete a file from the list of the container
        /// </summary>
        /// <param name="index">File to remove</param>
        public void DeleteFile(int index)
        {
            files.RemoveAt(index);  
        }
        /// <summary>
        /// Get a file from the list of the container
        /// </summary>
        /// <param name="index">Index of the file</param>
        /// <returns>The file</returns>
        public string GetFile(int index)
        {
            return files[index];
        }
        /// <summary>
        /// Get the last added file to the list of the container
        /// </summary>
        /// <returns>The file</returns>
        public string GetLastFile()
        {
            return files.Last();
        }
        // Clear files
        public void ClearFiles()
        {
            files.Clear();
            files.Add("");
        }
        /// <summary>
        /// Does a file exist in the list of the container ?
        /// </summary>
        /// <param name="file">File to search for</param>
        /// <returns>Boolean for file presence</returns>
        public bool FilesContain(string file)
        {
            return files.Contains(file);
        }
    }
}