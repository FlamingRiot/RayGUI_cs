namespace RayGUI_cs
{
    /*
        Color codes:
        White: Info
        Yellow: Warning
        Red: Error
    */
    /// <summary>Represents an instance of the static debugger.</summary>
    internal static class Debugger
    {
        /// <summary>Sends a message to the debug console.</summary>
        /// <param name="msg">Message to send.</param>
        public static void Send(string msg)
        {
            Console.WriteLine($"RayGUI: {msg}");
        }

        /// <summary>Sends a message to the debug console.</summary>
        /// <param name="msg">Message to send.</param>
        /// <param name="color">Color to use.</param>
        public static void Send(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"RayGUI: {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}