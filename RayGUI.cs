using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;

namespace RayGUI_cs
{
    public unsafe class RayGUI
    {   
        const int BORDER = 1;
        static Keys KEYS = new();
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
        /// <returns>Last file that was added to the container</returns>
        public static string DrawContainer(ref Container c)
        { 
            // Manage FileDropper containers
            if (c.Type == ContainerType.FileDropper)
            {
                if (IsFileDropped() && Hover((int)c.X, (int)c.Y, c.Width, c.Height))
                {
                    ImportFiles(ref c);
                }
            }

            // Draw container
            DrawRectangle(c.X - BORDER, c.Y - BORDER, c.Width + BORDER * 2, c.Height + BORDER * 2, c.BorderColor);
            DrawRectangle(c.X, c.Y, c.Width, c.Height, c.Color);

            return c.GetLastFile();
        }

        /// <summary>
        /// Import the dropped files in the corresponding container
        /// </summary>
        /// <param name="c">Corresponding container</param>
        public static void ImportFiles(ref Container c)
        {
            FilePathList filePathList = LoadDroppedFiles();
            string path = new ((sbyte*)filePathList.Paths[0]);
            string[] pathArray = path.Split('.');
            string[] pathArryBySlash = path.Split('\\');
            string fileName = pathArryBySlash.Last();

            // Copy file to output directory of the container
            if (!c.FilesContain(c.OutputFilePath + "\\" +fileName))
            {
                if (pathArray.Last() == c.ExtensionFile)
                {
                    try
                    {
                        File.Copy(path, c.OutputFilePath + "\\" + fileName, true);
                        c.AddFile(c.OutputFilePath + "\\" + fileName);
                        // Add file path to the container
                        TraceLog(TraceLogLevel.Info, "File " + fileName + " was received successfully");
                    }
                    catch
                    {
                        TraceLog(TraceLogLevel.Warning, "File could not be received, incorrect path or no project loaded");
                    }
                }
                else { TraceLog(TraceLogLevel.Warning, "File could not be received, required extension : ." + c.ExtensionFile); }
            }
            UnloadDroppedFiles(filePathList);
        }

        /// <summary>
        /// Draw tickbox on the screen
        /// </summary>
        /// <param name="t"></param>
        public static void DrawTickbox(ref Tickbox t)
        {
            int border = 1;

            // Manage ticking option
            if (Hover(t.X, t.Y, t.Width, t.Height))
            {
                DrawRectangle(t.X - border, t.Y - border, t.Width + border * 2, t.Height + border * 2, t.BorderColor);
                if (IsMouseButtonPressed(MouseButton.Left))
                {
                    t.Ticked = !t.Ticked;
                }
            }
            else
            {
                DrawRectangle(t.X - border, t.Y - border, t.Width + border * 2, t.Height + border * 2, t.BorderColor);
                if (!t.Ticked)
                {
                    DrawRectangle(t.X, t.Y, t.Width, t.Height, t.Color);
                }
                else if (t.Ticked)
                {
                    DrawRectangle(t.X, t.Y, t.Width, t.Height, t.BorderColor);
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
                // Manager copy-paste
                if (IsKeyDown(KeyboardKey.LeftControl) && IsKeyPressed(KeyboardKey.V))
                {
                    t.Text += GetClipboardText_();
                }
                else if (key != 0 && key != 259) t.Text += GetKeyString(key);
                
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

        /// <summary>
        /// Draw panel
        /// </summary>
        /// <param name="p">Panel</param>
        public static void DrawPanel(Panel p)
        {
            DrawTextureEx(p.Texture, new Vector2(p.X, p.Y), p.Rotation, p.Scale, Color.White);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        public static bool DrawDragDropBox(DragDropBox d)
        {
            // Draw box border
            DrawRectangleRounded(d.ExtRectangle, 5, 5, d.BorderColor);
            // Draw box interior
            DrawRectangleRounded(d.IntRectangle, 5, 5, d.Color);

            // Return focus
            return Hover(d.X, d.Y, d.Width, d.Height);
        }
    }
}