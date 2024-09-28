using Raylib_cs;
namespace RayGUI_cs
{
    /// <summary>Drag & Drop box component of the library</summary>
    public class DragDropBox : Component
    {
        /// <summary>Displayed text on the button.</summary>
        public string Text;

        /// <summary>Internal rectangle of the box</summary>
        public Rectangle IntRectangle;

        /// <summary>External rectangle of the box</summary>
        public Rectangle ExtRectangle;

        /// <summary>Intializes a new instance of a <see cref="DragDropBox"/>.</summary>
        /// <param name="x">X position of the box</param>
        /// <param name="y">Y position of the box</param>
        /// <param name="width">Width of the box</param>
        /// <param name="height">Height of the box</param>
        /// <param name="text">Text of the box</param>
        public DragDropBox(int x, int y, int width, int height, string text) : base(x, y, width, height)
        {
            Text = text;    
            IntRectangle = new(x, y, width, height);
            ExtRectangle = new(x - 1, y - 1, width + 2, height + 2);
        }

        /// <summary>Intializes a new instance of a <see cref="DragDropBox"/>.</summary>
        /// <param name="x">X position of the box</param>
        /// <param name="y">Y position of the box</param>
        /// <param name="width">Width of the box</param>
        /// <param name="height">Height of the box</param>
        /// <param name="text">Text of the box</param>
        public DragDropBox(int x, int y, int width, int height, string text, string tag) : base(x, y, width, height, tag)
        {
            Text = text;
            IntRectangle = new(x, y, width, height);
            ExtRectangle = new(x - 1, y - 1, width + 2, height + 2);
        }
    }
}