using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;

namespace RayGUI_cs
{
    public static unsafe partial class RayGUI
    {
        const int BORDER = 2;

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
    }
}
