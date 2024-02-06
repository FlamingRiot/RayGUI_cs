using Raylib_cs;

namespace RayGUI_cs
{
    public partial struct Tickbox
    {
        /// <summary>
        /// X coordinate of the tickbox
        /// </summary>
        public int X;

        /// <summary>
        /// Y coordinate of the tickbox
        /// </summary>
        public int Y;

        /// <summary>
        /// Is the tickbox ticked ?
        /// </summary>
        public bool Ticked;

        /// <summary>
        /// Background color of the label
        /// </summary>
        public Color Color;

        /// <summary>
        /// Border color of the label
        /// </summary>
        public Color BorderColor;

        public Tickbox(int x, int y, Color color)
        {
            this.X = x;
            this.Y = y;
            this.Ticked = false;
            this.Color = color;
            this.BorderColor = color;
        }
        public Tickbox(int x, int y, Color color, Color borderColor)
        {
            this.X = x;
            this.Y = y;
            this.Ticked = false;
            this.Color = color;
            this.BorderColor = borderColor;
        }
    }
}
