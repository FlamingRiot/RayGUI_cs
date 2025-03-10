#pragma warning disable CS8602

using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace RayGUI_cs
{
    /// <summary>RayGUI instance of the library.</summary>
    public unsafe class RayGUI
    {
        public const string VERSION = "2.0.3.1";

        /// <summary>Constant border size of components.</summary>
        internal const int BORDER = 1;

        /// <summary>Maximum of characters in components tag.</summary>
        internal const int MAX_TAG_LENGTH = 25;

        /// <summary>Tickbox width and height values.</summary>
        internal const int TICKBOX_SIZE = 16;

        /// <summary>Tickbox width and height values.</summary>
        internal static int DEFAULT_FONT_SIZE = 15;

        /// <summary>Global font of the GUI tool.</summary>
        public static Font Font;

        // Inernal variables
        internal static bool _fontLoaded = false;
        internal static Dictionary<int, bool> _activeContainers = new Dictionary<int, bool>();

        //------------------------------------------------------------------------------------
        // Window and GUI Functions (Module: Raygui)
        //------------------------------------------------------------------------------------

        /// <summary>Initializes the GUI tool.</summary>
        /// <param name="font">Custom font to use.</param>
        public static void LoadGUI(Font font)
        {
            // Set font
            SetTextureFilter(font.Texture, TextureFilter.Trilinear);
            Font = font;
            _fontLoaded = true;
            // Send debug text
            Debugger.Send("Initialized successfully with custom font", ConsoleColor.Green);
        }

        /// <summary>Deactivates the specified conatiner.</summary>
        public static void DeactivateGui(GuiContainer container)
        {
            _activeContainers.Remove(container._id);
        }

        /// <summary>Activates the specified container.</summary>
        public static void ActivateGui(GuiContainer container)
        {
            _activeContainers.Add(container._id, false);
        }

        /// <summary>Sets the default font size.</summary>
        /// <param name="size">Size to set.</param>
        public static void SetDefaultFontSize(int size)
        {
            DEFAULT_FONT_SIZE = size;
        }

        /// <summary>Checks if the mouse hovers an element.</summary>
        /// <param name="c">Component to check for.</param>
        /// <returns><see langword="true"/> if the mouse hovers the element. <see langword="false"/> otherwise.</returns>
        public static bool Hover(Component c)
        {
            Vector2 mouse = GetMousePosition();
            if (mouse.X < c.X + c.Width && mouse.X > c.X && mouse.Y < c.Y + c.Height && mouse.Y > c.Y)
            {
                return true;
            }
            else return false;
        }

        /// <summary>Checks if the mouse hovers an element.</summary>
        /// <param name="c">Component to check for.</param>
        /// <returns><see langword="true"/> if the mouse hovers the element. <see langword="false"/> otherwise.</returns>
        public static bool Hover(int x, int y, int width, int height)
        {
            Vector2 mouse = GetMousePosition();
            if (mouse.X < x + width && mouse.X > x && mouse.Y < y + height && mouse.Y > y)
            {
                return true;
            }
            else return false;
        }

        /// <summary>Measures the length of a text, based on whether a font is loaded or not.</summary>
        /// <param name="text">Text to measure.</param>
        /// <param name="FontSize">Font size to use.</param>
        /// <returns>Width and height of the text.</returns>
        internal static Vector2 MeasureComponentText(string text, int FontSize)
        {
            if (_fontLoaded) return MeasureTextEx(Font, text, FontSize, 1);
            else return new Vector2(MeasureText(text, FontSize), FontSize);
        }

        //------------------------------------------------------------------------------------
        // Update-needed draw functions
        //------------------------------------------------------------------------------------

        /// <summary>Draws a <see cref="Button"/> object to the screen</summary>
        /// <param name="button"><see cref="Button"/> to draw</param>
        internal static void DrawButton(Button button, int id)
        {
            DrawRectangle(button.X - BORDER, button.Y - BORDER, button.Width + BORDER * 2, button.Height + BORDER * 2, button.BorderColor);
            // Manage hover button color
            if (Hover(button) && _activeContainers.ContainsKey(id)) 
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

        /// <summary>Draws a <see cref="Textbox"/> component.</summary>
        /// <param name="t">Textbox to draw</param>
        internal static void DrawTextbox(Textbox t, int id)
        {
            // Manage box border
            DrawRectangle(t.X - BORDER, t.Y - BORDER, t.Width + BORDER * 2, t.Height + BORDER * 2, t.BorderColor);
            // Manage hover t color
            if (Hover(t) && !t.Focus && _activeContainers.ContainsKey(id)) SetMouseCursor(MouseCursor.IBeam);

            DrawRectangle(t.X, t.Y, t.Width, t.Height, t.BaseColor);

            // Draw text
            DrawTextPro(Font, t.Text, new Vector2(t.X + t.Width / 2 - t.TextSize.X / 2, t.Y + t.Height / 2 - t.TextSize.Y / 2), new Vector2(0, 0), 0, t.FontSize, 1, t.TextColor);
        }

        /// <summary>Draws a <see cref="Tickbox"/> component.</summary>
        /// <param name="t">Tickbox to draw.</param>
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

        /// <summary>Draws a <see cref="DropDown"/> list component.</summary>
        /// <param name="d">DropDown list to draw.</param>
        internal static void DrawDropDown(DropDown d, int id) 
        {
            d._buttons.ForEach(button =>
            {
                DrawButton(button, id);
            });
        }

        //------------------------------------------------------------------------------------
        // Static component functions
        //------------------------------------------------------------------------------------

        /// <summary>Draws a container to the screen.</summary>
        /// <param name="c">Container to draw</param>
        internal static void DrawContainer(DropZone c)
        {
            // Draw container
            DrawRectangle(c.X - BORDER, c.Y - BORDER, c.Width + BORDER * 2, c.Height + BORDER * 2, c.BorderColor);
            DrawRectangle(c.X, c.Y, c.Width, c.Height, c.BaseColor);
        }


        /// <summary>Draws a <see cref="Label"/> component.</summary>
        /// <param name="l">Label to draw</param>
        internal static void DrawLabel(Label l)
        {
            // Draw background
            DrawRectangle(l.X - BORDER, l.Y - BORDER, l.Width + BORDER * 2, l.Height + BORDER * 2, l.BorderColor);
            DrawRectangle(l.X, l.Y, l.Width, l.Height, l.BaseColor);
            DrawTextPro(Font, l.Text, new Vector2(l.X, l.Y + l.Height / 2 - l.TextSize.Y / 2), new Vector2(0, 0), 0, l.FontSize, 1, l.TextColor);
        }


        /// <summary>Draws a <see cref="Panel"/> component.</summary>
        /// <param name="p">Panel to draw.</param>
        internal static void DrawPanel(Panel p)
        {
            DrawTexturePro(p.Texture, p.SourceRectangle, p.TargetRectangle, Vector2.Zero, p.Rotation, Color.White);
        }

        //------------------------------------------------------------------------------------
        // Component lists managment
        //------------------------------------------------------------------------------------

        /// <summary>Draws a list of <see cref="Component"/>.</summary>
        /// <param name="components">List of <see cref="Component"/> to draw.</param>
        internal static void DrawGuiContainer(List<Component> components, ref bool focus, int id)
        {
            // Draw
            foreach (Component c in components) 
            {
                switch (c)
                {
                    case Button:
                        DrawButton((Button)c, id);
                        c.LightFocus = Hover(c);
                        break;
                    case DropZone:
                        DrawContainer((DropZone)c);
                        EventHandler.UpdateContainer((DropZone)c);
                        break;
                    case Label:
                        DrawLabel((Label)c);
                        break;
                    case Panel:
                        DrawPanel((Panel)c);
                        break;
                    case Textbox:
                        DrawTextbox((Textbox)c, id);
                        c.LightFocus = Hover(c);
                        break;
                    case Tickbox:
                        DrawTickbox((Tickbox)c);
                        c.LightFocus = Hover(c);
                        break;
                    case DropDown:
                        DrawDropDown((DropDown)c, id);
                        c.LightFocus = Hover(c);
                        break;
                }
            }
            // Update heavily focused textboxes
            components.Where(x => x is Textbox).Where(x => ((Textbox)x).Focus).ToList().ForEach(EventHandler.Update);
            if (components.Where((Component x) => x.LightFocus).ToList().Count == 0)
            {
                focus = false;
            }
            else
            {
                focus = true;
            }

            // Update
            if (IsMouseButtonPressed(MouseButton.Left) && _activeContainers.ContainsKey(id))
            {
                // Clear textboxes 
                components.Where(x => x is Textbox).ToList().ForEach(t =>
                {
                    if (!Hover((Textbox)t) && ((Textbox)t)._focus)
                    {
                        ((Textbox)t).EntryUpdate();
                    }
                }); 

                List<Component> actives = components.Where(x => x.LightFocus).ToList();
                // Update actives
                actives.ForEach(EventHandler.Update);
            }

            // Textbox tab update
            if (IsKeyPressed(KeyboardKey.Tab))
            {
                // Get current selected textbox
                try
                {
                    Textbox t = (Textbox)components.Where(x => x is Textbox).ToList().Where(x => ((Textbox)x).Focus).ToList()[0];
                    t.EntryUpdate();
                    int ti = components.IndexOf(t); // Get index of txb
                    int stIndex = -1;
                    bool nextFound = false;
                    // Go to next txb
                    foreach (Textbox nt in components.Where(x => x is Textbox).ToList())
                    {
                        if (stIndex == -1) stIndex = components.IndexOf(nt); // Gets first index of the list
                        if (components.IndexOf(nt) > ti)
                        {
                            EventHandler.Update(nt);
                            nextFound = true;
                            break;
                        }
                    }
                    if (!nextFound) EventHandler.Update(components[stIndex]);
                }
                catch
                {

                }
            }
        }
    }
}