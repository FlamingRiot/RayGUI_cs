using Raylib_cs;

namespace RayGUI_cs
{
    public partial struct Textbox
    {
        /// <summary>
        /// Value of the textbox
        /// </summary>
        public string Text;

        /// <summary>
        /// X coordinate of the object
        /// </summary>
        public int X;

        /// <summary>
        /// Y coordinate of the object
        /// </summary>
        public int Y;

        /// <summary>
        /// Width of the object
        /// </summary>
        public int Width;

        /// <summary>
        /// Height of the object
        /// </summary>
        public int Height;

        /// <summary>
        /// Color of the object
        /// </summary>
        public Color Color;

        /// <summary>
        /// Border color of the object
        /// </summary>
        public Color BorderColor;

        /// <summary>
        /// Does the box have the focus of the mouse ? 
        /// </summary>
        public bool Focus;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">Initial value of the box</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Textbox(string text, int x, int y, int width, int height, Color color, Color borderColor)
        {
            this.Text = text;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Color = color;
            this.BorderColor = borderColor;

            this.Focus = false;
        }
    }
}