using Raylib_cs;

namespace RayGUI_cs
{
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
        /// Maximum width
        /// </summary>
        public int MaxWidth;

        /// <summary>
        /// Maximum height
        /// </summary>
        public int MaxHeight;

        /// <summary>
        /// Background color of the container
        /// </summary>
        public Color Color;

        /// <summary>
        /// Border color of the container
        /// </summary>
        public Color BorderColor;

        /// <summary>
        /// Resize direction
        /// </summary>
        public string Resize;

        public Container(int x, int y, int width, int height, int maxWidth, int maxHeight, Color color, Color borderColor)
        {
            X = x; 
            Y = y;
            Width = width;
            Height = height;
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            Color = color;
            BorderColor = borderColor;

            Resize = "none";
        }
    }
}
