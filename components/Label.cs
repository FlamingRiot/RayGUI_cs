namespace RayGUI_cs
{
    public class Label : Component
    {
        /// <summary>
        /// Label text
        /// </summary>
        private string text;
        /// <summary>
        /// Label text
        /// </summary>
        public string Text { get { return text; } set { text = value; } }
        /// <summary>
        /// Label constructor
        /// </summary>
        /// <param name="x">Label X position</param>
        /// <param name="y">Label Y position</param>
        /// <param name="text">Label text</param>
        public Label(int x, int y, string text) : base(x, y, 0, 0)
        {
            this.text = text;
            this.Tag = "";
        }
        /// <summary>
        /// Label constructor
        /// </summary>
        /// <param name="x">Label X position</param>
        /// <param name="y">Label Y position</param>
        /// <param name="text">Label text</param>
        /// <param name="tag">Label tag</param>
        public Label(int x, int y, string text, string tag) : base(x, y, 0, 0, tag)
        {
            this.text = text;
        }
    }    
}