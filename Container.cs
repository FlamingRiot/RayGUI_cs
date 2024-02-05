using Raylib_cs;

namespace RayGUI_cs
{
    public partial struct Container
    {
        /// <summary>
        /// X coordinate (Right corner)
        /// </summary>
        public int X;

        /// <summary>
        /// Y coordinate (Left corner)
        /// </summary>
        public int Y;

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

        public Container(int x, int y, int width, int height, Color color, Color borderColor)
        {
            X = x; 
            Y = y; 
            Width = width;
            Height = height;
            Color = color;
            BorderColor = borderColor;
        }
    }
}
