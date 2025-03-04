using Raylib_cs;

namespace RayGUI_cs
{
    public class GuiContainer
    {
        private OrderedDictionary<string, Component> _components;

        public Color ColorA;
        public Color ColorB;

        public GuiContainer()
        {
            _components = new OrderedDictionary<string, Component>();
            ColorA = Color.Black;
            ColorB = Color.White;
        }

        public GuiContainer(Color colorA, Color colorB)
        {
            _components = new OrderedDictionary<string, Component>();
            ColorA = colorA;
            ColorB = colorB;
        }

        public void Add(string name, Component component)
        {
            // Apply GUI-container's color scheme
            component.BaseColor = ColorA;
            component.BorderColor = ColorB;
            component.HoverColor = ColorB;
            _components.Add(name, component);
        }

        public void Remove(string name)
        {
            _components.Remove(name);
        }

        public void Draw()
        {
            bool focus = false;
            RayGUI.DrawGuiContainer(_components.Values.ToList(), ref focus);
            if (!focus) Raylib.SetMouseCursor(MouseCursor.Default);
        }
    }
}
