using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;

namespace RayGUI_cs
{
    public unsafe partial class RayGUI
    {   
        const int BORDER = 1;
        static Keys KEYS = new Keys();
        static Color baseColor;
        static Color borderColor;
        //------------------------------------------------------------------------------------
        // Window and Graphics Device Functions (Module: core)
        //------------------------------------------------------------------------------------

        /// <summary>
        /// Initialize GUI tool
        /// </summary>
        public static void InitGUI(Color BaseColor, Color BorderColor)
        {
            // Disable exit key
            SetExitKey(KeyboardKey.Null);
            baseColor = BaseColor;
            borderColor = BorderColor;
        }

        /// <summary>
        /// Draw button on the screen
        /// </summary>
        /// <param name="button">Button to draw</param>
        /// <param name="position">Positon to draw the button</param>
        public static void DrawButton(Button button, Font font)
        {
            DrawRectangle(button.X - BORDER, button.Y - BORDER, button.Width + BORDER * 2, button.Height + BORDER * 2, button.BorderColor);
            // Manage hover button color
            Vector2 mouse = GetMousePosition();
            if (Hover(button.X, button.Y, button.Width, button.Height)) 
            {
                SetMouseCursor(MouseCursor.PointingHand);
                DrawRectangle((int)button.X, (int)button.Y, button.Width, button.Height, button.HoverColor);
            }
            else
            {
                DrawRectangle((int)button.X, (int)button.Y, button.Width, button.Height, button.Color);
            }
            // Manage button text
            font.BaseSize = 2;
            int txtLength = button.Text.Length;
            DrawTextPro(font, button.Text, new Vector2(button.X + button.Width / 2 - txtLength * 4, button.Y + button.Height / 3 -  5), new Vector2(0, 0), 0, 1, 1, Color.White);

            // Does user interacts with the buttons 
            IsButtonPressed(button);
        }

        /// <summary>
        /// Check if a button is pressed, returns boolean, activates event if true
        /// </summary>
        /// <param name="button">Button to check</param>
        /// <returns></returns>
        public static bool IsButtonPressed(Button button)
        {
            if (Hover(button.X, button.Y, button.Width, button.Height) && IsMouseButtonPressed(MouseButton.Left))
            {
                button.Activate();
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Draw container on the screen
        /// </summary>
        /// <param name="c"></param>
        public static Container DrawContainer(ref Container c)
        {
            // Manage FileDropper containers
            if (c.Type == ContainerType.FileDropper)
            {
                if (IsFileDropped() && Hover((int)c.X, (int)c.Y, c.Width, c.Height))
                {
                    ImportFiles(c);
                }
            }

            // Draw container
            DrawRectangle((int)c.X - BORDER, (int)c.Y - BORDER, c.Width + BORDER * 2, c.Height + BORDER * 2, c.BorderColor);
            DrawRectangle((int)c.X, (int)c.Y, c.Width, c.Height, c.Color);

            return c;
        }

        /// <summary>
        /// Import the dropped files in the corresponding container
        /// </summary>
        /// <param name="c">Corresponding container</param>
        public static void ImportFiles(Container c)
        {
            FilePathList filePathList = LoadDroppedFiles();
            string path = new string((sbyte*)filePathList.Paths[0]);
            string[] pathArray = path.Split('.');
            string[] pathArryBySlash = path.Split('\\');
            string fileName = pathArryBySlash.Last();

            // Copy file to output directory of the container
            if (!c.Files.Contains(c.OutputFilePath + fileName))
            {
                if (pathArray.Last() == c.ExtensionFile)
                {
                    File.Copy(path, "..\\..\\..\\" + c.OutputFilePath + fileName, true);
                    TraceLog(TraceLogLevel.Info, "File " + fileName + " was received successfully");
                }
                else { TraceLog(TraceLogLevel.Warning, "File could not be received, required extension : ." + c.ExtensionFile); }
            }
            // Add file path to the container
            c.Files.Add(c.OutputFilePath + fileName);
        }

        /// <summary>
        /// Draw tickbox on the screen
        /// </summary>
        /// <param name="t"></param>
        public static void DrawTickbox(ref Tickbox t)
        {
            int size = 16;
            int border = 1;

            // Manage ticking option
            if (Hover(t.X, t.Y, size, size))
            {
                DrawRectangle(t.X - border, t.Y - border, size + border * 2, size + border * 2, t.BorderColor);
                if (IsMouseButtonPressed(MouseButton.Left))
                {
                    t.Ticked = !t.Ticked;
                }
            }
            else
            {
                DrawRectangle(t.X - border, t.Y - border, size + border * 2, size + border * 2, t.BorderColor);
                if (!t.Ticked)
                {
                    DrawRectangle(t.X, t.Y, size, size, t.Color);
                }
                else if (t.Ticked)
                {
                    DrawRectangle(t.X, t.Y, size, size, t.BorderColor);
                }
            }
        }

        /// <summary>
        /// Draw label on the screen
        /// </summary>
        /// <param name="l"></param>
        public static void DrawLabel(Label l, Font font)
        {
            font.BaseSize = 2;
            DrawTextPro(font, l.Text, new Vector2(l.X, l.Y), new Vector2(0, 0), 0, 1, 1, Color.White);
        }

        /// <summary>
        /// Draw a textbox on the screen
        /// </summary>
        /// <param name="t">Textbox</param>
        /// <param name="font">Font to use</param>
        public static Textbox DrawTextbox(ref Textbox t, Font font)
        {
            // Manage box border
            DrawRectangle(t.X - BORDER, t.Y - BORDER, t.Width + BORDER * 2, t.Height + BORDER * 2, t.BorderColor);
            // Manage hover t color
            if (Hover(t.X, t.Y, t.Width, t.Height) && !t.Focus)
            {
                DrawRectangle((int)t.X, (int)t.Y, t.Width, t.Height, t.BorderColor);
            }
            else
            {
                DrawRectangle((int)t.X, (int)t.Y, t.Width, t.Height, t.Color);
            }

            // Manage button text
            font.BaseSize = 2;
            int txtLength = t.Text.Length;
            DrawTextPro(font, t.Text, new Vector2(t.X + t.Width / 2 - txtLength * 4, t.Y + t.Height / 3 - 5), new Vector2(0, 0), 0, 1, 1, Color.White);

            // Manage modifying option
            if (Hover(t.X, t.Y, t.Width, t.Height))
            {
                SetMouseCursor(MouseCursor.IBeam);
                if (IsMouseButtonPressed(MouseButton.Left))
                {
                    t.Focus = true;
                    t.Color = ColorTint(t.Color, Color.Blue);
                }
            }
            else { SetMouseCursor(MouseCursor.Default); }
            if (t.Focus)
            {
                int key = GetKeyPressed();

                if (t.Text.Length != 0)
                {
                    if (key == 259)
                    {
                        t.Text = t.Text.Remove(t.Text.Length - 1);
                    }

                    if (IsKeyDown(KeyboardKey.Backspace))
                    {
                        if (t.DeltaBack == 0.0) { t.DeltaBack = GetTime(); }
                        if (GetTime() - t.DeltaBack >= 0.5) { t.Text = t.Text.Remove(t.Text.Length - 1); }
                    }
                    else { t.DeltaBack = 0.0; }
                }
                if (key != 0 && key != 259) t.Text += GetKeyString(key);
                
            }
            if (IsKeyPressed(KeyboardKey.Escape) || IsKeyPressed(KeyboardKey.Enter)) { t.Focus = false; t.Color = baseColor; }

            return t;
        }

        /// <summary>
        /// Check if mouse is over any element by passing its position and scale properties
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="width">Width scale</param>
        /// <param name="height">height scale</param>
        /// <returns></returns>
        public static bool Hover(int x, int y, int width, int height)
        {
            Vector2 mouse = GetMousePosition();
            if (mouse.X < x + width && mouse.X > x && mouse.Y < y + height && mouse.Y > y)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Get the pressed key by passing the key code
        /// </summary>
        /// <param name="keycode">Code of the key</param>
        /// <returns></returns>
        public static string GetKeyString(int keycode)
        {
            // Specific cases
            switch (keycode)
            {
                // Space bar
                case 32:return " ";
                default:
                    try
                    {
                        if (IsKeyDown(KeyboardKey.LeftShift))
                        {
                            return KEYS.UCKey[keycode - 65];
                        }
                        else
                        {
                            return KEYS.LCKey[keycode - 65];
                        }
                    }
                    catch
                    {
                        TraceLog(TraceLogLevel.Warning, "Key not implemented - Check your keyboard you dumbass");
                        return "";
                    }
            }
        }
    }
}