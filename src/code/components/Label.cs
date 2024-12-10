using Raylib_cs;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace RayGUI_cs
{
    /// <summary>Label component of the library</summary>
    public class Label : Component
    {
        public static readonly Color DEFAULT_BACKGROUND = new Color(0, 0, 0, 0);

        private string text;
        private int fontSize;

        /// <summary>Text color of the label.</summary>
        public Color TextColor;

        /// <summary>Text size in pixels.</summary>
        internal Vector2 TextSize;

        /// <summary>Displayed text on the button.</summary>
        public string Text
        {
            get { return text; }
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

        /// <summary>Initializes a new instance of a <see cref="Label"/> object.</summary>
        /// <param name="x">X position of the label</param>
        /// <param name="y">Y position of the label</param>
        /// <param name="text">Text of the label</param>
        public Label(int x, int y, string text) : base(x, y, 0, 0)
        {
            this.text = "";
            Text = text;
            FontSize = RayGUI.DEFAULT_FONT_SIZE;
            TextColor = Color.White;
            BaseColor = DEFAULT_BACKGROUND;
        }

        /// <summary>Initializes a new instance of a <see cref="Label"/> object.</summary>
        /// <param name="x">X position of the label</param>
        /// <param name="y">Y position of the label</param>
        /// <param name="text">Text of the label</param>
        public Label(int x, int y, int width, int height, string text) : base(x, y, width, height)
        {
            this.text = "";
            Text = text;
            FontSize = RayGUI.DEFAULT_FONT_SIZE;
            TextColor = Color.White;
            BaseColor = DEFAULT_BACKGROUND;
        }

        /// <summary>Initializes a new instance of a <see cref="Label"/> object.</summary>
        /// <param name="x">X position of the label</param>
        /// <param name="y">Y position of the label</param>
        /// <param name="text">Text of the label</param>
        /// <param name="tag">Tag of the label</param>
        public Label(int x, int y, string text, string tag) : base(x, y, 0, 0, tag)
        {
            this.text = "";
            Text = text;
            FontSize = RayGUI.DEFAULT_FONT_SIZE;
            TextColor = Color.White;
            BaseColor = DEFAULT_BACKGROUND;
        }
    }    
}