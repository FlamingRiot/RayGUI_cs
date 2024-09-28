namespace RayGUI_cs
{
    /// <summary>Label component of the library</summary>
    public class Label : Component
    {
        /// <summary>Displayed text on the button.</summary>
        public string Text;

        /// <summary>Initializes a new instance of a <see cref="Label"/> object.</summary>
        /// <param name="x">X position of the label</param>
        /// <param name="y">Y position of the label</param>
        /// <param name="text">Text of the label</param>
        public Label(int x, int y, string text) : base(x, y, 0, 0)
        {
            Text = text;
        }

        /// <summary>Initializes a new instance of a <see cref="Label"/> object.</summary>
        /// <param name="x">X position of the label</param>
        /// <param name="y">Y position of the label</param>
        /// <param name="text">Text of the label</param>
        /// <param name="tag">Tag of the label</param>
        public Label(int x, int y, string text, string tag) : base(x, y, 0, 0, tag)
        {
            Text = text;
        }
    }    
}