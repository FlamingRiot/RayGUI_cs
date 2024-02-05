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
            DrawRectangle((int)button.X - BORDER, (int)button.Y - BORDER, button.Width + BORDER * 2, button.Height + BORDER * 2, button.BorderColor);
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
        }

        /// <summary>
        /// Check if a button is pressed, returns boolean
        /// </summary>
        /// <param name="button">Button to check</param>
        /// <returns></returns>
        public static bool IsButtonPressed(Button button)
        {
            Vector2 mouse = GetMousePosition();
            if (mouse.X < button.X + button.Width && mouse.X > button.X && mouse.Y < button.Y + button.Height && mouse.Y > button.Y && IsMouseButtonPressed(MouseButton.Left))
            {
                    return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Draw container on the screen
        /// </summary>
        /// <param name="c"></param>
        public static void DrawContainer(Container c)
        {
            // Manage the resize option
            Vector2 mouse = GetMousePosition();
            switch (mouse)
            {
                // Left
                case Vector2 i when i.X < c.X + 5 && i.X > c.X - 5 && i.Y < c.Height - 5 && i.Y > c.Y + 5:
                    SetMouseCursor(MouseCursor.ResizeEw);
                    break;
                // Right
                case Vector2 i when i.X < c.X + c.Width + 5 && i.X > c.X + c.Width - 5 && i.Y < c.Height - 5 && i.Y > c.Y + 5:
                    SetMouseCursor(MouseCursor.ResizeEw);
                    break;
                // Top
                case Vector2 i when i.X < c.X + c.Width - 5 && i.X > c.X + 5 && i.Y < c.Y + 5 && i.Y > c.Y - 5:
                    SetMouseCursor(MouseCursor.ResizeNs);
                    break;
                // Bottom
                case Vector2 i when i.X < c.X + c.Width - 5 && i.X > c.X + 5 && i.Y < c.Y + c.Height + 5 && i.Y > c.Y + c.Height - 5:
                    SetMouseCursor(MouseCursor.ResizeNs);
                    break;
                // Top-Left
                case Vector2 i when i.X < c.X + 5 && i.X > c.X - 5 && i.Y < c.Y + 5 && i.Y > c.Y - 5:
                    SetMouseCursor(MouseCursor.ResizeNwse);
                    break;
                // Top-Right
                case Vector2 i when i.X < c.X + c.Width + 5 && i.X > c.X + c.Width - 5 && i.Y < c.Y + 5 && i.Y > c.Y - 5:
                    SetMouseCursor(MouseCursor.ResizeNesw);
                    break;
                // Bottom-Left
                case Vector2 i when i.X < c.X + 5 && i.X > c.X - 5 && i.Y < c.Y + c.Height + 5 && i.Y > c.Y + c.Height - 5:
                    SetMouseCursor(MouseCursor.ResizeNesw);
                    break;
                // Bottom-Right
                case Vector2 i when i.X < c.X + c.Width + 5 && i.X > c.X + c.Width - 5 && i.Y < c.Y + c.Height + 5 && i.Y > c.Y + c.Height - 5:
                    SetMouseCursor(MouseCursor.ResizeNwse);
                    break;
                // Not
                default:
                    SetMouseCursor(MouseCursor.Default);
                    break;
            }

            DrawRectangle((int)c.X - BORDER, (int)c.Y - BORDER, c.Width + BORDER * 2, c.Height + BORDER * 2, c.BorderColor);
            DrawRectangle((int)c.X, (int)c.Y, c.Width, c.Height, c.Color);
        }
    }
}
