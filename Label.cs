using Raylib_cs;
namespace RayGUI_cs
{
    public partial struct Label
    {
        /// <summary>
        /// X coordinate of the label
        /// </summary>
        public int X;

        /// <summary>
        /// Y coordinate of the label
        /// </summary>
        public int Y;

        /// <summary>
        /// Label text
        /// </summary>
        public string Text;

        public Label(int x, int y, string text)
        {
            this.X = x; 
            this.Y = y; 
            this.Text = text;
        }
    }    
}
