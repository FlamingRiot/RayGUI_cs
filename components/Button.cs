using Raylib_cs;
using System.Security.Principal;
namespace RayGUI_cs
{
    /// <summary>
    /// Delegate event
    /// </summary>
    public delegate void Event();
    /// <summary>
    /// Button action system
    /// </summary>
    public enum ButtonType
    {
        Custom,
        PathFinder,
        ColorPicker
    }
    /// <summary>
    /// 2-Dimensional button
    /// </summary>
    public class Button : Component
    {
        /// <summary>
        /// Background color for the button
        /// </summary>
        private Color color;
        /// <summary>
        /// Border color for the button
        /// </summary>
        private Color borderColor;
        /// <summary>
        /// Hover color for the button
        /// </summary>
        private Color hoverColor;
        /// <summary>
        /// Text of the button
        /// </summary>
        private string text;
        /// <summary>
        /// Type of the button event
        /// </summary>
        private ButtonType type;
        /// <summary>
        /// Event of the button (if set to custom)
        /// </summary>
        private Event? action;
        /// <summary>
        /// Event of the button (if set to custom)
        /// </summary>
        public Event? Event { set { action = value; } }
        /// <summary>
        /// Background color for the button
        /// </summary>
        public Color Color { get { return color; } set { color = value; } }
        /// <summary>
        /// Border color for the button
        /// </summary>
        public Color BorderColor { get { return borderColor; } set { borderColor = value; } }
        /// <summary>
        /// Hover color for the button
        /// </summary>
        public Color HoverColor { get { return hoverColor; } set { hoverColor = value; } }
        /// <summary>
        /// Text of the button
        /// </summary>
        public string Text { get { return text; } set { text = value; } }
        /// <summary>
        /// Type of the button event
        /// </summary>
        public ButtonType Type { get { return type; } set { type = value; } }
        /// <summary>
        /// Button Constructor
        /// </summary>
        /// <param name="x">Button X position</param>
        /// <param name="y">Button Y position</param>
        /// <param name="width">Button width</param>
        /// <param name="height">Button height</param>
        /// <param name="text">Button text</param>
        /// <param name="color">Button color</param>
        /// <param name="borderColor">Button second color</param>
        public Button(string text, int x, int y, int width, int height, Color color, Color borderColor):base(x, y, width, height)
        {
            // Position assignment
            Width = width + text.Length * 6;
            X = x - text.Length * 8;
            this.text = text;
            this.Tag = "";
            // Color assignment
            Color = color;
            BorderColor = borderColor;
            HoverColor = borderColor;
            // Automatically set (has to be modified afterwards if needed)
            Type = ButtonType.Custom;
        }
        /// <summary>
        /// Button Constructor
        /// </summary>
        /// <param name="x">Button X position</param>
        /// <param name="y">Button Y position</param>
        /// <param name="width">Button width</param>
        /// <param name="height">Button height</param>
        /// <param name="text">Button text</param>
        /// <param name="color">Button color</param>
        /// <param name="borderColor">Button second color</param>
        /// <param name="tag">Button tag</param>
        public Button(string text, int x, int y, int width, int height, Color color, Color borderColor, string tag) : base(x, y, width, height, tag)
        {
            // Position assignment
            Width = width + text.Length * 6;
            X = x - text.Length * 8;
            this.text = text;
            // Color assignment
            Color = color;
            BorderColor = borderColor;
            HoverColor = borderColor;
            // Automatically set (has to be modified afterwards if needed)
            Type = ButtonType.Custom;
        }
        /// <summary>
        /// Activate button event, if not set to custom
        /// </summary>
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
                    if (action is not null) action();
                    break;
            }
        }
    }
}