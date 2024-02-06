namespace RayGUI_cs
{
    public partial struct Tickbox
    {
        /// <summary>
        /// X coordinate of the tickbox
        /// </summary>
        public int X;

        /// <summary>
        /// Y coordinate of the tickbox
        /// </summary>
        public int Y;

        /// <summary>
        /// Is the tickbox ticked ?
        /// </summary>
        public bool Ticked;

        public Tickbox(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Ticked = false;
        }
    }
}
