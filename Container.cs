using Raylib_cs;

namespace RayGUI_cs
{
    public enum ContainerType
    {
        Custom = 0,
        FileDropper
    }

    public partial struct Container
    {
        /// <summary>
        /// X coordinate (Right corner)
        /// </summary>
        public float X;

        /// <summary>
        /// Y coordinate (Left corner)
        /// </summary>
        public float Y;

        /// <summary>
        /// Conatiner width
        /// </summary>
        public int Width;

        /// <summary>
        /// Container height
        /// </summary>
        public int Height;

        /// <summary>
        /// Background color of the container
        /// </summary>
        public Color Color;

        /// <summary>
        /// Border color of the container
        /// </summary>
        public Color BorderColor;

        /// <summary>
        /// Type of the container
        /// </summary>
        public ContainerType Type;

        /// <summary>
        /// The file path for the output directory
        /// </summary>
        public string OutputFilePath;

        /// <summary>
        /// Acceptable file types (works only for the File Dropper type)
        /// </summary>
        public string ExtensionFile;

        /// <summary>
        /// Paths of the container's files
        /// </summary>
        public List<string> Files;

        /// <summary>
        /// Container tag
        /// </summary>
        public string Tag;

        public Container(int x, int y, int width, int height, Color color, Color borderColor, string Tag)
        {
            X = x; 
            Y = y;
            Width = width;
            Height = height;
            Color = color;
            BorderColor = borderColor;
            this.Tag = Tag;

            ExtensionFile = "";
            Files = new List<string>();
            Type = ContainerType.Custom;
            OutputFilePath = "";
        }
    }
}
