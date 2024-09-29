using Raylib_cs;
using System.Numerics;

namespace RayGUI_cs
{
    /// <summary>Textbox component of the library</summary>
    public class Textbox : Component
    {
        private int fontSize;
        private string? text;

        /// <summary>Text size in pixels.</summary>
        internal Vector2 TextSize;

        /// <summary>Text color of the label.</summary>
        public Color TextColor;

        /// <summary>Displayed text on the textbox.</summary>
        public string? Text { get { return text; }
            set
            {
                text = value;
                TextSize = Raylib.MeasureTextEx(RayGUI.Font, text, FontSize, 1);
            }
        }

        /// <summary>Font size of the buttons's text.</summary>
        public int FontSize
        {
            get { return fontSize; }
            set
            {
                fontSize = value;
                TextSize = Raylib.MeasureTextEx(RayGUI.Font, Text, fontSize, 1);
            }
        }

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
            FontSize = RayGUI.DEFAULT_FONT_SIZE;
            TextColor = Color.White;
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
            FontSize = RayGUI.DEFAULT_FONT_SIZE;
            TextColor = Color.White;
            // Interaction assignment
            Focus = false;
            DeltaBack = 0.0;
        }
    }
}