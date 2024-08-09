namespace RayGUI_cs
{
    public class Component
    {
        /// <summary>
        /// Component X position
        /// </summary>
        private int x;
        /// <summary>
        /// Component Y position
        /// </summary>
        private int y;
        /// <summary>
        /// Component width
        /// </summary>
        private int width;
        /// <summary>
        /// Component height
        /// </summary>
        private int height;
        /// <summary>
        /// Component tag
        /// </summary>
        private string tag;
        /// <summary>
        /// Component X position
        /// </summary>
        public int X { get { return x; } set { x = value; } }
        /// <summary>
        /// Component Y position
        /// </summary>
        public int Y { get { return y; } set { y = value; } }
        /// <summary>
        /// Component width
        /// </summary>
        public int Width { get { return width; } set { width = value; } }
        /// <summary>
        /// Component height
        /// </summary>
        public int Height { get { return height; } set { height = value; } }
        /// <summary>
        /// Component tag
        /// </summary>
        public string Tag { get { return tag; } set { tag = value; } }
        /// <summary>
        /// Component constructor
        /// </summary>
        /// <param name="x">Component X position</param>
        /// <param name="y">Component Y position</param>
        /// <param name="width">Component width</param>
        /// <param name="height">Component height</param>
        public Component(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.tag = "";
        }
        /// <summary>
        /// Component constructor
        /// </summary>
        /// <param name="x">Component X position</param>
        /// <param name="y">Component Y position</param>
        /// <param name="width">Component width</param>
        /// <param name="height">Component height</param>
        /// <param name="tag">Component tag</param>
        public Component(int x, int y, int width, int height, string tag)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.tag = tag;
        }
        /// <summary>
        /// Stringified Component informations
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Position: <{x},{y}> Size: <{width} {height}>";
        }
    }
}