namespace RayGUI_cs
{
    /// <summary>Textbox component of the library</summary>
    public class Textbox : Component
    {
        /// <summary>Displayed text on the textbox.</summary>
        public string Text;

        /// <summary>Focus boolean value of the box</summary>
        public bool Focus;

        /// <summary>Delta time between backspace key pressed and erasing</summary>
        public double DeltaBack;

        /// <summary>Initializes a new instance of a <see cref="Textbox"/> object.</summary>
        /// <param name="x">X position of the textbox</param>
        /// <param name="y">Y position of the textbox</param>
        /// <param name="width">Width of the textbox</param>
        /// <param name="height"">Height of the textbox</param>
        /// <param name="text">Initial text of the textbox</param>
        public Textbox(int x, int y, int width, int height, string text) : base(x, y, width, height)
        {
            Text = text;

            // Size correction
            Width = width + text.Length * 6;
            // Position correction
            if (X - text.Length * 8 < 0)
                X = 0;
            else
                X -= text.Length * 8;

            // Interaction assignment
            Focus = false;
            DeltaBack = 0.0;
        }

        /// <summary>Initializes a new instance of a <see cref="Textbox"/> object.</summary>
        /// <param name="x">X position of the textbox</param>
        /// <param name="y">Y position of the textbox</param>
        /// <param name="width">Width of the textbox</param>
        /// <param name="height"">Height of the textbox</param>
        /// <param name="text">Initial text of the textbox</param>
        /// <param name="tag">Tag of the textbox</param>
        public Textbox(int x, int y, int width, int height, string text, string tag) : base(x, y, width, height, tag)
        {
            Text = text;

            // Size correction
            Width = width + text.Length * 6;
            // Position correction
            if (X - text.Length * 8 < 0)
                X = 0;
            else
                X -= text.Length * 8;

            // Interaction assignment
            Focus = false;
            DeltaBack = 0.0;
        }
    }
}