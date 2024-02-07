using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;

namespace RayGUI_cs
{
    public static unsafe partial class RayGUI
    {   
        const int BORDER = 1;

        //------------------------------------------------------------------------------------
        // Window and Graphics Device Functions (Module: core)
        //------------------------------------------------------------------------------------

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
            if (mouse.X < button.X + button.Width && mouse.X > button.X && mouse.Y < button.Y + button.Height && mouse.Y > button.Y) 
            {
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
            Vector2 mouse = GetMousePosition();
            if (mouse.X < button.X + button.Width && mouse.X > button.X && mouse.Y < button.Y + button.Height && mouse.Y > button.Y && IsMouseButtonPressed(MouseButton.Left))
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
        public static void DrawContainer(ref Container c)
        {
            // Manage the resize option
            Vector2 mouse = GetMousePosition();
            switch (mouse)
            {
                // Left
                case Vector2 i when i.X < c.X + 5 && i.X > c.X - 5 && i.Y < c.Height - 5 && i.Y > c.Y + 5:
                    SetMouseCursor(MouseCursor.ResizeEw);
                    if (IsMouseButtonDown(MouseButton.Left)) { c.Resize = "left"; }
                    break;
                // Right
                case Vector2 i when i.X < c.X + c.Width + 5 && i.X > c.X + c.Width - 5 && i.Y < c.Height - 5 && i.Y > c.Y + 5:
                    SetMouseCursor(MouseCursor.ResizeEw);
                    if (IsMouseButtonDown(MouseButton.Left)) { c.Resize = "right"; }
                    break;
                // Top
                case Vector2 i when i.X < c.X + c.Width - 5 && i.X > c.X + 5 && i.Y < c.Y + 5 && i.Y > c.Y - 5:
                    SetMouseCursor(MouseCursor.ResizeNs);
                    if (IsMouseButtonDown(MouseButton.Left)) { c.Resize = "top"; }
                    break;
                // Bottom
                case Vector2 i when i.X < c.X + c.Width - 5 && i.X > c.X + 5 && i.Y < c.Y + c.Height + 5 && i.Y > c.Y + c.Height - 5:
                    SetMouseCursor(MouseCursor.ResizeNs);
                    if (IsMouseButtonDown(MouseButton.Left)) { c.Resize = "bottom"; }
                    break;
                // Top-Left
                case Vector2 i when i.X < c.X + 5 && i.X > c.X - 5 && i.Y < c.Y + 5 && i.Y > c.Y - 5:
                    SetMouseCursor(MouseCursor.ResizeNwse);
                    if (IsMouseButtonDown(MouseButton.Left)) { c.Resize = "top-left"; }
                    break;
                // Top-Right
                case Vector2 i when i.X < c.X + c.Width + 5 && i.X > c.X + c.Width - 5 && i.Y < c.Y + 5 && i.Y > c.Y - 5:
                    SetMouseCursor(MouseCursor.ResizeNesw);
                    if (IsMouseButtonDown(MouseButton.Left)) { c.Resize = "top-right"; }
                    break;
                // Bottom-Left
                case Vector2 i when i.X < c.X + 5 && i.X > c.X - 5 && i.Y < c.Y + c.Height + 5 && i.Y > c.Y + c.Height - 5:
                    SetMouseCursor(MouseCursor.ResizeNesw);
                    if (IsMouseButtonDown(MouseButton.Left)) { c.Resize = "bottom-left"; }
                    break;
                // Bottom-Right
                case Vector2 i when i.X < c.X + c.Width + 5 && i.X > c.X + c.Width - 5 && i.Y < c.Y + c.Height + 5 && i.Y > c.Y + c.Height - 5:
                    SetMouseCursor(MouseCursor.ResizeNwse);
                    if (IsMouseButtonDown(MouseButton.Left)) { c.Resize = "bottom-right"; }
                    break;
                // Not
                default:
                    SetMouseCursor(MouseCursor.Default);
                    break;
            }

            // Stop the resize option
            if (IsMouseButtonReleased(MouseButton.Left)) { c.Resize = "none"; }
            
            switch (c.Resize)
            {
                case "left":
                    c.X = mouse.X;
                    break;
                case "right":
                    c.Width = (int)mouse.X - (int)c.X;
                    break;
                case "top":
                    c.Y = mouse.Y;
                    break;
                case "bottom":
                    c.Height = (int)mouse.Y - (int)c.Y;
                    break;
                case "bottom-right":
                    c.Width = (int)mouse.X - (int)c.X;
                    c.Height = (int)mouse.Y - (int)c.Y;
                    break;
                case "bottom-left":
                    c.Height = (int)mouse.Y - (int)c.Y;
                    c.X = mouse.X;
                    break;
                case "top-left":
                    c.Y = mouse.Y;
                    c.X = mouse.X;
                    break;
                case "top-right":
                    c.Y = mouse.Y;
                    c.Width = (int)mouse.X - (int)c.X;
                    break;
            }

            // Manage FileDropper containers
            if (c.Type == ContainerType.FileDropper)
            {
                if (IsFileDropped() && mouse.X < c.X + c.Width && mouse.X > c.X && mouse.Y < c.Y + c.Height && mouse.Y > c.Y)
                {
                    ImportFiles(c);
                }
            }

            // Draw container
            DrawRectangle((int)c.X - BORDER, (int)c.Y - BORDER, c.Width + BORDER * 2, c.Height + BORDER * 2, c.BorderColor);
            DrawRectangle((int)c.X, (int)c.Y, c.Width, c.Height, c.Color);
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
            Vector2 mouse = GetMousePosition();

            // Manage ticking option
            if (mouse.X < t.X + size && mouse.X > t.X && mouse.Y < t.Y + size && mouse.Y > t.Y)
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
    }
}
