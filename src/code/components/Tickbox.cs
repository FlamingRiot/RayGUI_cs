namespace RayGUI_cs
{
    /// <summary>Textbox component of the library</summary>
    public class Tickbox : Component
    {
        /// <summary>Tick boolean value of the box.</summary>
        public bool Ticked;

        // Internal font size used for better matching
        internal static int InternalFontSize = RayGUI.FindMatchingFont(RayGUI.DEFAULT_FONT_SIZE);

        /// <summary>Initializes a new instance of a <see cref="Tickbox"/> object.</summary>
        /// <param name="x">X position of the tickbox</param>
        /// <param name="y">Y position of the tickbox</param>
        public Tickbox(int x, int y) : base(x, y, RayGUI.TICKBOX_SIZE, RayGUI.TICKBOX_SIZE)
        {
            Ticked = false;
        }
    }
}