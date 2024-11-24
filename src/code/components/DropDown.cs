using Raylib_cs;

namespace RayGUI_cs
{
    /// <summary>Represents an instance of <see cref="DropDown"/> list.</summary>
    public class DropDown : Component
    {
        //------------------------------------------------------------------------------------
        // Constants
        //------------------------------------------------------------------------------------
        public const int DEFAULT_REPEATED_HEIGHT = 28;

        //------------------------------------------------------------------------------------
        // Private attributes
        //------------------------------------------------------------------------------------
        internal readonly List<Button> _buttons;

        //------------------------------------------------------------------------------------
        // Public attributes and properties
        //------------------------------------------------------------------------------------
        public int RepeatedHeight { get; set; } = DEFAULT_REPEATED_HEIGHT;

        /// <summary>Overall background color.</summary>
        public Color BackgroundColor { set
            {
                foreach (Button button in _buttons) 
                {
                    button.BaseColor = value;
                }
            } 
        }

        /// <summary>Creates an instance of <see cref="DropDown"/> list.</summary>
        /// <param name="x">X Position of the list.</param>
        /// <param name="y">Y Position of the top of the list.</param>
        /// <param name="width">Width of the list.</param>
        /// <param name="buttons">List of buttons to create (by name).</param>
        public DropDown(int x, int y, int width, List<string> buttons) : base(x, y, width, DEFAULT_REPEATED_HEIGHT * buttons.Count)
        {
            _buttons = new List<Button>();
            for (int i = 0; i < buttons.Count; i++)
            {
                _buttons.Add(new Button(buttons[i], x, y + RepeatedHeight * i, width, RepeatedHeight));
            }
        }

        /// <summary>Sets the event function for every button with the given name.</summary>
        /// <param name="name">Name of the button.</param>
        /// <param name="action">Action function to set.</param>
        public void SetButtonEvent(string name, Event action)
        {
            _buttons.Where(x => x.Text == name).ToList().ForEach(button => button.Event = action);
        }

        /// <summary>Sets the event function for the button at given location.</summary>
        /// <param name="index">Index of the button.</param>
        /// <param name="action">Action function to set.</param>
        public void SetButtonEvent(int index, Event action)
        {
            _buttons[index].Event = action;
        }

        /// <summary>Returns a hash code based on the combined informations of the instance.</summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(X);
            hash.Add(Y);
            hash.Add(Width);
            hash.Add(Height);
            hash.Add(Tag);
            hash.Add(_buttons);
            hash.Add(RepeatedHeight);

            return hash.ToHashCode();
        }
    }
}