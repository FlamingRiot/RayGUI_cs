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

        public Button(int width, int height, Color color, Color borderColor)
        {
            Width = width;
            Height = height;
            Color = color;
            BorderColor = borderColor;
            HoverColor = color;
        }

        public Button(int width, int height, Color color, Color borderColor, Color hoverColor)
        {
            Width = width;
            Height = height;
            Color = color;
            BorderColor = borderColor;
            HoverColor = hoverColor;
        }
    }
}