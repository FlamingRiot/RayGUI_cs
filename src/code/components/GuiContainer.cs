using Raylib_cs;

namespace RayGUI_cs
{
    /// <summary>Represents an instance of a GUI container.</summary>
    public unsafe class GuiContainer
    {
        internal int _id;
        private readonly OrderedDictionary<string, Component> _components;
        
        public bool _focus;
        public Color ColorA;
        public Color ColorB;

        /// <summary>Links the internal list of components.</summary>
        /// <param name="key">Component key.</param>
        /// <returns>Component value.</returns>
        public Component this[string key]
        {
            get
            {
                return _components[key];
            }
            set
            {
                _components[key] = value;
            }
        }

        /// <summary>Creates a default instance of <see cref="GuiContainer"/>.</summary>
        public GuiContainer()
        {
            _components = new OrderedDictionary<string, Component>();
            ColorA = Color.Black;
            ColorB = Color.White;
            InternalizeContainer();
        }

        /// <summary>Creates a custom instance of <see cref="GuiContainer"/>.</summary>
        /// <param name="colorA">Primary GUI color.</param>
        /// <param name="colorB">Secondary GUI color.</param>
        public GuiContainer(Color colorA, Color colorB)
        {
            _components = new OrderedDictionary<string, Component>();
            ColorA = colorA;
            ColorB = colorB;
            InternalizeContainer();
        }

        /// <summary>Adds a GUI component to the container.</summary>
        /// <param name="name">Component name.</param>
        /// <param name="component">Component to add.</param>
        public void Add(string name, Component component)
        {
            // Apply GUI-container's color scheme
            component.BaseColor = ColorA;
            component.BorderColor = ColorB;
            component.HoverColor = ColorB;
            _components.Add(name, component);
        }

        /// <summary>Removes a GUI component from the container.</summary>
        /// <param name="name">Component name.</param>
        public void Remove(string name)
        {
            _components.Remove(name);
        }

        /// <summary>Displays and updates the GUI components.</summary>
        public void Draw()
        {
            _focus = false;
            RayGUI.DrawGuiContainer([.._components.Values], ref _focus, _id);
            if (RayGUI._activeContainers.ContainsKey(_id)) RayGUI._activeContainers[_id] = _focus;

            // Check if cursor occupied
            bool check = false;
            for (int i = 0; i < RayGUI._activeContainers.Count; i++) 
            {
                if (RayGUI._activeContainers.Values.ToList()[i]) check = true;
            }
            if (!check) Raylib.SetMouseCursor(MouseCursor.Default);
        }

        private void InternalizeContainer()
        {
            _id = Random.Shared.Next(0, 1000);
            RayGUI._activeContainers.Add(_id, _focus);
        }
    }
}
