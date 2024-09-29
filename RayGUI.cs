using static Raylib_cs.Raylib;
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
            SetTextureFilter(font.Texture, TextureFilter.Trilinear);
            RayGUI.Font = font;

            // Send debug text
            Console.ForegroundColor = ConsoleColor.Green;
            TraceLog(TraceLogLevel.Info, "RayGUI_cs: Initialized successfully");
            Console.ForegroundColor = ConsoleColor.White;
        }


        /// <summary>Checks if the mouse hovers an element.</summary>
        /// <param name="c">Component to check for.</param>
        /// <returns><see langword="true"/> if the mouse hover the element. <see langword="false"/> otherwise.</returns>
        public static bool Hover(Component c)
        {
            Vector2 mouse = GetMousePosition();
            if (mouse.X < c.X + c.Width && mouse.X > c.X && mouse.Y < c.Y + c.Height && mouse.Y > c.Y)
            {
                return true;
            }
            else return false;
        }

        /// <summary>Draws a <see cref="Button"/> object to the screen</summary>
        /// <param name="button"><see cref="Button"/> to draw</param>
        internal static void DrawButton(Button button)
        {
            DrawRectangle(button.X - BORDER, button.Y - BORDER, button.Width + BORDER * 2, button.Height + BORDER * 2, button.BorderColor);
            // Manage hover button color
            if (Hover(button)) 
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
        }

        /// <summary>Draws a container to the screen.</summary>
        /// <param name="c">Container to draw</param>
        internal static void DrawContainer(Container c)
        {
            // Draw container
            DrawRectangle(c.X - BORDER, c.Y - BORDER, c.Width + BORDER * 2, c.Height + BORDER * 2, c.BorderColor);
            DrawRectangle(c.X, c.Y, c.Width, c.Height, c.BaseColor);
        }

        /// <summary>Draws a <see cref="Tickbox"/> component.</summary>
        /// <param name="t"></param>
        internal static void DrawTickbox(Tickbox t)
        {
            if (Hover(t))
            {
                DrawRectangle(t.X - BORDER, t.Y - BORDER, t.Width + BORDER * 2, t.Height + BORDER * 2, t.BorderColor);
            }
            else
            {
                DrawRectangle(t.X - BORDER, t.Y - BORDER, t.Width + BORDER * 2, t.Height + BORDER * 2, t.BorderColor);
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
        internal static void DrawLabel(Label l)
        {
            DrawTextPro(Font, l.Text, new Vector2(l.X, l.Y), new Vector2(0, 0), 0, l.FontSize, 1, l.TextColor);
        }

        /// <summary>Draws a <see cref="Textbox"/> component.</summary>
        /// <param name="t">Textbox to draw</param>
        internal static void DrawTextbox(Textbox t)
        {
            // Manage box border
            DrawRectangle(t.X - BORDER, t.Y - BORDER, t.Width + BORDER * 2, t.Height + BORDER * 2, t.BorderColor);
            // Manage hover t color
            if (Hover(t) && !t.Focus)
            {
                DrawRectangle(t.X, t.Y, t.Width, t.Height, t.BorderColor);
            }
            else
            {
                DrawRectangle(t.X, t.Y, t.Width, t.Height, t.BaseColor);
            }

            // Draw text
            DrawTextPro(Font, t.Text, new Vector2(t.X + t.Width / 2 - t.TextSize.X / 2, t.Y + t.Height / 2 - t.TextSize.Y / 2), new Vector2(0, 0), 0, t.FontSize, 1, t.TextColor);
        }


        /// <summary>Draws a <see cref="Panel"/> component.</summary>
        /// <param name="p">Panel to draw.</param>
        internal static void DrawPanel(Panel p)
        {
            DrawTextureEx(p.Texture, new Vector2(p.X, p.Y), p.Rotation, p.Scale, Color.White);
        }


        /// <summary>Checks for dropped files.</summary>
        /// <param name="c">Container to update</param>
        internal static Container UpdateContainer(Container c)
        {
            // Manage FileDropper containers
            if (c.Type == ContainerType.FileDropper)
            {
                if (IsFileDropped() && Hover(c))
                {
                    return ImportFiles(c);
                }
                return c;
            }
            return c;
        }

        /// <summary>Updates a <see cref="Tickbox"/> component.</summary>
        /// <param name="t">Tickbox to update.</param>
        /// <returns><see langword="true"/> if the box is ticked. <see langword="false"/> otherwise.</returns>
        internal static Tickbox UpdateTickbox(Tickbox t)
        {
            t.Ticked = !t.Ticked;
            return t;
        }

        /// <summary>Updates a <see cref="Textbox"/> component.</summary>
        /// <param name="t">Textbox to update.</param>
        /// <returns>Updated textbox.</returns>
        internal static Textbox UpdateTextbox(Textbox t)
        {
            t.Focus = true;
            t.BaseColor = ColorTint(t.BaseColor, Color.Blue);

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

            if (IsKeyPressed(KeyboardKey.Escape) || IsKeyPressed(KeyboardKey.Enter)) { t.Focus = false; t.BaseColor = BaseColor; }

            return t;
        }

        /// <summary>Imports files in a container</summary>
        /// <param name="c">Corresponding container</param>
        internal static Container ImportFiles(Container c)
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

            // Return modified container
            return c;
        }

        /// <summary>Gets the corresponding key to a keycode</summary>
        /// <param name="keycode">Code of the key</param>
        /// <returns>The key</returns>
        internal static string GetKeyString(int keycode)
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

        //------------------------------------------------------------------------------------
        // Component lists managment
        //------------------------------------------------------------------------------------

        /// <summary>Draws a list of <see cref="Component"/>.</summary>
        /// <param name="components">List of <see cref="Component"/> to draw.</param>
        public static void DrawGUIList(List<Component> components)
        {
            // Draw
            foreach (Component c in components) 
            {
                // Check for light focus
                components[components.IndexOf(c)].LightFocus = Hover(c);
                switch (c)
                {
                    case Button:
                        DrawButton((Button)c);
                        break;
                    case Container:
                        DrawContainer((Container)c);
                        break;
                    case Label:
                        DrawLabel((Label)c); 
                        break;
                    case Panel:
                        DrawPanel((Panel)c);
                        break;
                    case Textbox:
                        DrawTextbox((Textbox)c);
                        break;
                    case Tickbox:
                        DrawTickbox((Tickbox)c);    
                        break;
                }
            }
            // Update heavily focused textboxes
            components.Where(x => x is Textbox).Where(x => ((Textbox)x).Focus).ToList().ForEach(Update);

            // Update
            if (IsMouseButtonPressed(MouseButton.Left))
            {
                List<Component> actives = components.Where(x => x.LightFocus).ToList();
                // Update actives
                actives.ForEach(Update);
            }
        }

        /// <summary>Updates a <see cref="Component"/> in a list of <see cref="Component"/>.</summary>
        /// <param name="c"><see cref="Component"/> to update.</param>
        internal static void Update(Component c)
        {
            switch (c)
            {
                case Button:
                    ((Button)c).Activate();
                    break;
                case Textbox:
                    c = UpdateTextbox((Textbox)c);
                    break;
                case Tickbox:
                    c = UpdateTickbox((Tickbox)c);
                    break;
                case Container:
                    c = UpdateContainer((Container)c);
                    break;
            }
        }
    }
}