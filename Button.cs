using Raylib_cs;
namespace RayGUI_cs
{
    /// <summary>
    /// Button action system
    /// </summary>
    public enum ButtonType
    {
        Custom = 0,
        PathFinder
    }

    /// <summary>
    /// 2D button
    /// </summary>
    public partial struct Button
    {
        /// <summary>
        /// X coordinate of the button
        /// </summary>
        public int X;

        /// <summary>
        /// Y coordinate of the button
        /// </summary>
        public int Y;

        /// <summary>
        /// Button width
        /// </summary>
        public int Width;

        /// <summary>
        /// Button height
        /// </summary>
        public int Height;

        /// <summary>
        /// Background color for the button
        /// </summary>
        public Color Color;

        /// <summary>
        /// Border color for the button
        /// </summary>
        public Color BorderColor;

        /// <summary>
        /// Hover color for the button
        /// </summary>
        public Color HoverColor;

        /// <summary>
        /// Text of the button
        /// </summary>
        public string Text;

        /// <summary>
        /// Type of the button event
        /// </summary>
        public ButtonType Type;

        public Button(int width, int height, int x, int y, Color color, Color borderColor)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;
            Color = color;
            BorderColor = borderColor;
            HoverColor = color;

            // Automatically set
            Text = "";
            Type = ButtonType.Custom;
        }

        public Button(int width, int height, int x, int y, Color color, Color borderColor, Color hoverColor)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;
            Color = color;
            BorderColor = borderColor;
            HoverColor = hoverColor;

            // Automatically set
            Text = "";
            Type = ButtonType.Custom;
        }

        public void Activate()
        {
            switch (Type)
            {
                case ButtonType.Custom:
                    Raylib.TraceLog(TraceLogLevel.Info, "This button has not any event asigned to it");
                    break;
                case ButtonType.PathFinder:
                    // Find the current user
                    string userString = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    string[] userArray = userString.Split('\\');
                    string user = userArray[1];

                    // Open the file explorer
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    string _path = "c:/users/" + user + "/downloads";
                    startInfo.Arguments = string.Format("/C start {0}", _path);
                    process.StartInfo = startInfo;
                    process.Start();
                    Console.WriteLine("Explo lancé");
                    break;
            }
        }
    }
}