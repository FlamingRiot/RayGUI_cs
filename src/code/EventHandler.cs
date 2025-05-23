﻿#pragma warning disable CS8602

using Raylib_cs;
using static Raylib_cs.Raylib;
using static RayGUI_cs.RayGUI;

namespace RayGUI_cs
{
    /// <summary>Represents a static instance of <see cref="EventHandler"/>.</summary>
    internal static class EventHandler
    {
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
                    UpdateTextbox((Textbox)c);
                    break;
                case Tickbox:
                    UpdateTickbox((Tickbox)c);
                    break;
                case DropDown:
                    UpdateDropDown((DropDown)c);
                    break;
            }
        }

        /// <summary>Checks for dropped files.</summary>
        /// <param name="c">Container to update</param>
        public static DropZone UpdateContainer(DropZone c)
        {
            // Manage FileDropper containers
            if (IsFileDropped() && Hover(c))
            {
                return DropZone.ImportFiles(c);
            }
            return c;
        }

        /// <summary>Updates a <see cref="Tickbox"/> component.</summary>
        /// <param name="t">Tickbox to update.</param>
        /// <returns><see langword="true"/> if the box is ticked. <see langword="false"/> otherwise.</returns>
        private static void UpdateTickbox(Tickbox t)
        {
            t.Ticked = !t.Ticked;
        }

        /// <summary>Updates a <see cref="Textbox"/> component.</summary>
        /// <param name="t">Textbox to update.</param>
        /// <returns>Updated textbox.</returns>
        private static void UpdateTextbox(Textbox t)
        {
            if ((IsMouseButtonPressed(MouseButton.Left) || IsKeyPressed(KeyboardKey.Tab)) && !t._focus) 
            { 
                t._focus = true;
                t.HoverColor = t.BaseColor;
                t.BaseColor = t.BorderColor;
            }

            int key = GetCharPressed();

            if (t.Text is not null && t.Text.Length != 0)
            {
                if (IsKeyPressed(KeyboardKey.Backspace))
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
            // Manage copy-paste
            if (IsKeyDown(KeyboardKey.LeftControl) && IsKeyPressed(KeyboardKey.V))
            {
                t.Text += GetClipboardText_();
            }
            else if (key != 0 && key != 259)
            {
                switch (t.Filter)
                {
                    case Textbox.TextFilter.None:
                        t.Text += Convert.ToString((char)key);
                        break;
                    case Textbox.TextFilter.Naturals:
                        if (key >= 48 && key <= 57) t.Text += Convert.ToString((char)key);
                        // Manage '-' character
                        if (key == 45 && t.Text?.Length == 0) t.Text += Convert.ToString((char)key); 
                        break;
                    case Textbox.TextFilter.Decimals:
                        if (key >= 48 && key <= 57) // Numbers
                        {
                            t.Text += Convert.ToString((char)key);
                        }
                        else if (key == 46 && !t.Text.Contains('.')) // '.' character
                        {
                            if (!t.Text.Contains('-') && t.Text.Length > 0) t.Text += Convert.ToString((char)key);
                            if (t.Text.Contains('-') && t.Text.Length > 1) t.Text += Convert.ToString((char)key);
                        }
                        // Manage '-' character
                        if (key == 45 && t.Text?.Length == 0) t.Text += Convert.ToString((char)key);
                        break;
                }
            }
            if (IsKeyPressed(KeyboardKey.Escape) || IsKeyPressed(KeyboardKey.Enter)) { t.EntryUpdate(); }
        }

        /// <summary>Updates the events of a DropDown list.</summary>
        /// <param name="d">DropDown list to update.</param>
        private static void UpdateDropDown(DropDown d)
        {
            d._buttons.ForEach(button =>
            {
                if (Hover(button)) button.Activate();
            });
        }
    }
}