using Raylib_cs;
namespace RayGUI_cs
{
    public class Tickbox : Component
    {
        /// <summary>
        /// Is the tickbox ticked ? (haha.)
        /// </summary>
        private bool ticked;
        /// <summary>
        /// Tickbox color
        /// </summary>
        private Color color;
        /// <summary>
        /// Tickbox secondary color
        /// </summary>
        private Color borderColor;
        /// <summary>
        /// Is the tickbox ticked ? (haha.)
        /// </summary>
        public bool Ticked { get { return ticked; } set { ticked = value; } }
        /// <summary>
        /// Tickbox color
        /// </summary>
        public Color Color { get { return color; } set { color = value; } }
        /// <summary>
        /// Tickbox secondary color
        /// </summary>
        public Color BorderColor { get { return borderColor; } set { borderColor = value; } }
        /// <summary>
        /// Tickbox constructor
        /// </summary>
        /// <param name="x">Tickbox X position</param>
        /// <param name="y">Tickbox Y position</param>
        /// <param name="color">Tickbox main color</param>
        /// <param name="borderColor">Tickbox secondary color</param>
        public Tickbox(int x, int y, Color color, Color borderColor) : base(x, y, 16, 16)
        {
            this.Ticked = false;
            this.Color = color;
            this.BorderColor = borderColor;
            this.Tag = "";
        }
        /// <summary>
        /// Tickbox constructor
        /// </summary>
        /// <param name="x">Tickbox X position</param>
        /// <param name="y">Tickbox Y position</param>
        /// <param name="color">Tickbox main color</param>
        /// <param name="borderColor">Tickbox secondary color</param>
        /// <param name="tag">Tickbox tag</param>
        public Tickbox(int x, int y, Color color, Color borderColor, string tag) : base(x, y, 16, 16, tag)
        {
            this.Ticked = false;
            this.Color = color;
            this.BorderColor = borderColor;
        }
    }
}