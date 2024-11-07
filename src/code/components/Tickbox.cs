namespace RayGUI_cs
{
    /// <summary>Textbox component of the library</summary>
    public class Tickbox : Component
    {
        /// <summary>Tick boolean value of the box.</summary>
        public bool Ticked;

        /// <summary>Initializes a new instance of a <see cref="Tickbox"/> object.</summary>
        /// <param name="x">X position of the tickbox</param>
        /// <param name="y">Y position of the tickbox</param>
        public Tickbox(int x, int y) : base(x, y, RayGUI.TICKBOX_SIZE, RayGUI.TICKBOX_SIZE)
        {
            Ticked = false;
        }

        /// <summary>Initializes a new instance of a <see cref="Tickbox"/> object.</summary>
        /// <param name="x">X position of the tickbox</param>
        /// <param name="y">Y position of the tickbox</param>
        /// <param name="tag">Tag of the tickbox</param>
        public Tickbox(int x, int y, string tag) : base(x, y, RayGUI.TICKBOX_SIZE, RayGUI.TICKBOX_SIZE, tag)
        {
            Ticked = false;
        }
    }
}