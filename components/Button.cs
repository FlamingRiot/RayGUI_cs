using System.Numerics;
using System.Security.Principal;
using Raylib_cs;

namespace RayGUI_cs
{
    /// <summary>Represents an activation function for the buttons.</summary>
    public delegate void Event();
    
    /// <summary>Button actions system.</summary>
    public enum ButtonType
    {
        Custom,
        PathFinder,
        ColorPicker
    }

    /// <summary>Button component of the library</summary>
    public class Button : Component
    {
        private int fontSize;
        private string? text;

        /// <summary>Text size in pixels.</summary>
        internal Vector2 TextSize;

        /// <summary>Text color of the label.</summary>
        public Color TextColor;

        /// <summary>Action type of the button.</summary>
        public ButtonType Type;

        /// <summary>Event function of the button.</summary>
        public Event? Action;

        /// <summary>Displayed text on the button.</summary>
        public string? Text { get { return text; }
            set 
            {
                text = value;
                TextSize = Raylib.MeasureTextEx(RayGUI.Font, text, FontSize, 1);
            }
        }

        /// <summary>Font size of the buttons's text.</summary>
        public int FontSize { get { return fontSize; }
            set 
            {
                fontSize = value;
                TextSize = Raylib.MeasureTextEx(RayGUI.Font, Text, fontSize, 1);
            } 
        }

        /// <summary>Initializes a <see cref="Button"/> object.</summary>
        /// <param name="x">X position of the button</param>
        /// <param name="y">Y position of the button</param>
        /// <param name="width">Width of the button</param>
        /// <param name="height">Height of the button</param>
        /// <param name="text">Text of the button</param>
        public Button(string text, int x, int y, int width, int height):base(x, y, width, height)
        {
            Text = text;
            FontSize = RayGUI.DEFAULT_FONT_SIZE;
            TextColor = Color.White;
            // Automatically set (has to be modified afterwards if needed)
            Type = ButtonType.Custom;
        }

        /// <summary>Initializes a <see cref="Button"/> object.</summary>
        /// <param name="x">X position of the button</param>
        /// <param name="y">Y position of the button</param>
        /// <param name="width">Width of the button</param>
        /// <param name="height">Height of the button</param>
        /// <param name="text">Text of the button</param>
        /// <param name="tag">Tag of the button</param>
        public Button(string text, int x, int y, int width, int height, string tag) : base(x, y, width, height, tag)
        {
            Text = text;
            FontSize = RayGUI.DEFAULT_FONT_SIZE;
            TextColor = Color.White;
            // Automatically set (has to be modified afterwards if needed)
            Type = ButtonType.Custom;
        }

        /// <summary>Activates the event associated to the button</summary>
        public void Activate()
        {
            switch (Type)
            {
                case ButtonType.PathFinder:
                    // Find the current user
                    string userString = WindowsIdentity.GetCurrent().Name;
                    string[] userArray = userString.Split('\\');
                    string user = userArray.Last();

                    // Open the file explorer
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    string _path = "c:/users/" + user + "/downloads";
                    startInfo.Arguments = string.Format("/C start {0}", _path);
                    process.StartInfo = startInfo;
                    process.Start();
                    Console.WriteLine("Expolrer launched");
                    break;
                case ButtonType.ColorPicker:
                    break;
                case ButtonType.Custom:
                    if (Action is not null) Action();
                    break;
            }
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
            hash.Add(Text);
            hash.Add(Type);

            return hash.ToHashCode();
        }
    }
}