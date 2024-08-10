using Raylib_cs;
namespace RayGUI_cs
{
    public class DragDropBox : Component
    {
        /// <summary>
        /// Box text
        /// </summary>
        private string text;
        /// <summary>
        /// Box main color
        /// </summary>
        private Color color;
        /// <summary>
        /// Box secondary color
        /// </summary>
        private Color borderColor;
        /// <summary>
        /// Box rectangle
        /// </summary>
        private Rectangle intRectangle;
        /// <summary>
        /// Box extern rectangle
        /// </summary>
        private Rectangle extRectangle;
        /// <summary>
        /// Box text
        /// </summary>
        public string Text { get { return text; } set { text = value; } }
        /// <summary>
        /// Box main color
        /// </summary>
        public Color Color { get { return color; } set { color = value; } }
        /// <summary>
        /// Box secondary color
        /// </summary>
        public Color BorderColor { get { return borderColor; } set { borderColor = value; } }
        /// <summary>
        /// Box rectangle
        /// </summary>
        public Rectangle IntRectangle { get { return intRectangle; } set { intRectangle = value; } }
        /// <summary>
        /// Box rectangle
        /// </summary>
        public Rectangle ExtRectangle { get { return extRectangle; } set { extRectangle = value; } }
        /// <summary>
        /// DragDropBox constructor
        /// </summary>
        /// <param name="x">Box X position</param>
        /// <param name="y">Box Y postiton</param>
        /// <param name="width">Box width</param>
        /// <param name="height">Box height</param>
        /// <param name="text">Box text</param>
        /// <param name="color">Box main color</param>
        /// <param name="borderColor">Box secondary color</param>
        public DragDropBox(int x, int y, int width, int height, string text, Color color, Color borderColor) : base(x, y, width, height)
        {
            this.text = text;
            this.color = color;
            this.borderColor = borderColor;
            this.intRectangle = new(x, y, width, height);
            this.extRectangle = new(x - 1, y - 1, width + 2, height + 2);
        }
        /// <summary>
        /// DragDropBox constructor
        /// </summary>
        /// <param name="x">Box X position</param>
        /// <param name="y">Box Y postiton</param>
        /// <param name="width">Box width</param>
        /// <param name="height">Box height</param>
        /// <param name="text">Box text</param>
        /// <param name="color">Box main color</param>
        /// <param name="borderColor">Box secondary color</param>
        /// <param name="tag">Box tag</param>
        public DragDropBox(int x, int y, int width, int height, string text, Color color, Color borderColor, string tag) : base(x, y, width, height, tag)
        {
            this.text = text;
            this.color = color;
            this.borderColor = borderColor;
            this.intRectangle = new(x, y, width, height);
            this.extRectangle = new(x - 1, y - 1, width + 2, height + 2);
        }
    }
}