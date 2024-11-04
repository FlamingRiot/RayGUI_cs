using Raylib_cs;
using static Raylib_cs.Raylib;
using static RayGUI_cs.RayGUI;

namespace RayGUI_cs
{
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

        /// <summary>Checks for dropped files.</summary>
        /// <param name="c">Container to update</param>
        private static Container UpdateContainer(Container c)
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
        private static Tickbox UpdateTickbox(Tickbox t)
        {
            t.Ticked = !t.Ticked;
            return t;
        }

        /// <summary>Updates a <see cref="Textbox"/> component.</summary>
        /// <param name="t">Textbox to update.</param>
        /// <returns>Updated textbox.</returns>
        private static Textbox UpdateTextbox(Textbox t)
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
            // Manage copy-paste
            if (IsKeyDown(KeyboardKey.LeftControl) && IsKeyPressed(KeyboardKey.V))
            {
                t.Text += GetClipboardText_();
            }
            else if (key != 0 && key != 259) t.Text += GetKeyString(key);

            if (IsKeyPressed(KeyboardKey.Escape) || IsKeyPressed(KeyboardKey.Enter)) { t.Focus = false; t.BaseColor = BaseColor; }

            return t;
        }
    }
}
