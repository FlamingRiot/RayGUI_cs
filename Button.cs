using Raylib_cs;
namespace RayGUI_cs
{
    /// <summary>
    /// 2D button
    /// </summary>
    public partial struct Button
    {
        /// <summary>
        /// Button width
        /// </summary>
        public int Width;

        /// <summary>
        /// Button height
        /// </summary>
        public int Height;

        /// <summary>
        /// Background color for the button
        /// </summary>
        public Color Color;

        /// <summary>
        /// Border color for the button
        /// </summary>
        public Color BorderColor;

        /// <summary>
        /// Hover color for the button
        /// </summary>
        public Color HoverColor;

        /// <summary>
        /// X coordinate of the button
        /// </summary>
        public int X;

        /// <summary>
        /// Y coordinate of the button
        /// </summary>
        public int Y;

        /// <summary>
        /// Text of the button
        /// </summary>
        public string Text;

        public Button(int width, int height, int x, int y, Color color, Color borderColor)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;
            Color = color;
            BorderColor = borderColor;
            HoverColor = color;

            // Automatically set
            Text = "";
        }

        public Button(int width, int height, int x, int y, Color color, Color borderColor, Color hoverColor)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;
            Color = color;
            BorderColor = borderColor;
            HoverColor = hoverColor;

            // Automatically set
            Text = "";
        }
    }
}