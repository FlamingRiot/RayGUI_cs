﻿using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;

namespace RayGUI_cs
{
    /// <summary>RayGUI instance of the library</summary>
    public unsafe class RayGUI
    {   
        /// <summary>Constant border size of components</summary>
        internal const int BORDER = 1;

        /// <summary>Maximum of characters in components tag</summary>
        internal const int MAX_TAG_LENGTH = 25;

        /// <summary>Tickbox width and height values</summary>
        internal const int TICKBOX_SIZE = 16;

        /// <summary>Tickbox width and height values</summary>
        internal const int DEFAULT_FONT_SIZE = 15;

        /// <summary><see cref="Keys"/> object hosting the key informations</summary>
        static Keys KEYS;

        /// <summary>Primary <see cref="Color"/> of the GUI tool</summary>
        public static Color BaseColor;

        /// <summary>Primary <see cref="Color"/> of the GUI tool</summary>
        public static Color BorderColor;

        /// <summary>Global font of the GUI tool</summary>
        public static Font Font;

        //------------------------------------------------------------------------------------
        // Window and Graphics Device Functions (Module: core)
        //------------------------------------------------------------------------------------

        /// <summary>Initialize GUI tool</summary>
        /// <param name="color1">Primary color of the GUI tool</param>
        /// <param name="color2">Secondary color of the GUI tool</param>
        public static void InitGUI(Color color1, Color color2, Font font)
        {
            // Init keys object
            RayGUI.KEYS = new();
            // Set colors
            RayGUI.BaseColor = color1;
            RayGUI.BorderColor = color2;
            // Set font
            //font.BaseSize = 2;
            SetTextureFilter(font.Texture, TextureFilter.Trilinear);
            RayGUI.Font = font;

            // Send debug text
            Console.ForegroundColor = ConsoleColor.Green;
            TraceLog(TraceLogLevel.Info, "RayGUI_cs: Initialized successfully");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>Draws a <see cref="Button"/> object to the screen</summary>
        /// <param name="button"><see cref="Button"/> to draw</param>
        public static void DrawButton(Button button)
        {
            DrawRectangle(button.X - BORDER, button.Y - BORDER, button.Width + BORDER * 2, button.Height + BORDER * 2, button.BorderColor);
            // Manage hover button color
            if (Hover(button.X, button.Y, button.Width, button.Height)) 
            {
                SetMouseCursor(MouseCursor.PointingHand);
                DrawRectangle(button.X, button.Y, button.Width, button.Height, button.HoverColor);
            }
            else
            {
                DrawRectangle(button.X, button.Y, button.Width, button.Height, button.BaseColor);
            }
            // Draw text
            DrawTextPro(Font, button.Text, new Vector2(button.X + button.Width / 2 - button.TextSize.X / 2, button.Y + button.Height / 2 - button.TextSize.Y / 2), new Vector2(0, 0), 0, button.FontSize, 1, button.TextColor);

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
        /// Draw container on the screen and check for imported files
        /// </summary>
        /// <param name="c">Container to draw</param>
        /// <returns>Last file that was added to the container</returns>
        public static void DrawContainer(ref Container c)
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
            DrawRectangle(c.X, c.Y, c.Width, c.Height, c.BaseColor);
        }
        /// <summary>
        /// Draw container on the screen
        /// </summary>
        /// <param name="c">Container to draw</param>
        public static void DrawContainer(Container c)
        {
            // Draw container
            DrawRectangle(c.X - BORDER, c.Y - BORDER, c.Width + BORDER * 2, c.Height + BORDER * 2, c.BorderColor);
            DrawRectangle(c.X, c.Y, c.Width, c.Height, c.BaseColor);
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
                    DrawRectangle(t.X, t.Y, t.Width, t.Height, t.BaseColor);
                }
                else if (t.Ticked)
                {
                    DrawRectangle(t.X, t.Y, t.Width, t.Height, t.BorderColor);
                }
            }
        }

        /// <summary>Draws a <see cref="Label"/> component.</summary>
        /// <param name="l">Label to draw</param>
        public static void DrawLabel(Label l)
        {
            DrawTextPro(Font, l.Text, new Vector2(l.X, l.Y), new Vector2(0, 0), 0, l.FontSize, 1, l.TextColor);
        }

        /// <summary>
        /// Draw a textbox on the screen
        /// </summary>
        /// <param name="t">Textbox</param>
        /// <param name="font">Font to use</param>
        public static Textbox DrawTextbox(ref Textbox t)
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
                DrawRectangle((int)t.X, (int)t.Y, t.Width, t.Height, t.BaseColor);
            }

            // Draw text
            DrawTextPro(Font, t.Text, new Vector2(t.X + t.Width / 2 - t.TextSize.X / 2, t.Y  + t.Height / 2 - t.TextSize.Y / 2), new Vector2(0, 0), 0, t.FontSize, 1, t.TextColor);

            // Manage modifying option
            if (Hover(t.X, t.Y, t.Width, t.Height))
            {
                SetMouseCursor(MouseCursor.IBeam);
                if (IsMouseButtonPressed(MouseButton.Left))
                {
                    t.Focus = true;
                    t.BaseColor = ColorTint(t.BaseColor, Color.Blue);
                }
            }
            if (t.Focus)
            {
                int key = GetKeyPressed();

                if (t.Text is not null && t.Text.Length != 0)
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
            if (IsKeyPressed(KeyboardKey.Escape) || IsKeyPressed(KeyboardKey.Enter)) { t.Focus = false; t.BaseColor = BaseColor; }

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
    }
}