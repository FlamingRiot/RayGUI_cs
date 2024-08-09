using Raylib_cs;
namespace RayGUI_cs
{
    public class Textbox : Component
    {
        /// <summary>
        /// Value of the textbox
        /// </summary>
        private string text;
        /// <summary>
        /// Color of the object
        /// </summary>
        private Color color;
        /// <summary>
        /// Border color of the object
        /// </summary>
        private Color borderColor;
        /// <summary>
        /// Does the box have the focus of the mouse ? 
        /// </summary>
        private bool focus;
        /// <summary>
        /// Delta time of the back key being pressed
        /// </summary>
        private double deltaBack;
        /// <summary>
        /// Value of the textbox
        /// </summary>
        public string Text { get { return text; } set { text = value; } }
        /// <summary>
        /// Color of the object
        /// </summary>
        public Color Color { get { return color; } set { color = value; } }
        /// <summary>
        /// Border color of the object
        /// </summary>
        public Color BorderColor { get { return borderColor; } set { borderColor = value; } }
        /// <summary>
        /// Does the box have the focus of the mouse ?
        /// </summary>
        public bool Focus { get { return focus; } set { focus = value; } }
        /// <summary>
        /// Delta time of the back key being pressed
        /// </summary>
        public double DeltaBack { get { return deltaBack; } set { deltaBack = value; } }

        /// <summary>
        /// Textbox constructor
        /// </summary>
        /// <param name="x">Textbox X position</param>
        /// <param name="y">Textbox Y position</param>
        /// <param name="width">Textbox width</param>
        /// <param name="height"">Textbox height</param>
        /// <param name="color">Textbox main color</param>
        /// <param name="borderColor">Textbox secondary color</param>
        /// <param name="text">Initial value of the textbox</param>
        public Textbox(int x, int y, int width, int height, string text, Color color, Color borderColor) : base(x, y, width, height)
        {
            // Position assignment
            this.text = text;
            this.X = x - text.Length * 8;
            this.Width = width + text.Length * 6;
            // Color assignment
            this.color = color;
            this.borderColor = borderColor;

            // Interaction assignment
            this.focus = false;
            this.deltaBack = 0.0;
        }
        /// <summary>
        /// Textbox constructor
        /// </summary>
        /// <param name="x">Textbox X position</param>
        /// <param name="y">Textbox Y position</param>
        /// <param name="width">Textbox width</param>
        /// <param name="height"">Textbox height</param>
        /// <param name="color">Textbox main color</param>
        /// <param name="borderColor">Textbox secondary color</param>
        /// <param name="text">Initial value of the textbox</param>
        /// <param name="tag">Textbox tag</param>
        public Textbox(int x, int y, int width, int height, string text, Color color, Color borderColor, string tag) : base(x, y, width, height, tag)
        {
            // Position assignment
            this.text = text;
            this.X = x - text.Length * 8;
            this.Width = width + text.Length * 6;
            // Color assignment
            this.color = color;
            this.borderColor = borderColor;

            // Interaction assignment
            this.focus = false;
            this.deltaBack = 0.0;
        }
    }
}