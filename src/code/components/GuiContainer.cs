using Raylib_cs;
using System.ComponentModel;

namespace RayGUI_cs
{
    /// <summary>Represents an instance of a GUI container.</summary>
    public unsafe class GuiContainer
    {
        internal int _id;
        private readonly OrderedDictionary<string, Component> _components;

        private int _defaultFontSize = RayGUI.DEFAULT_FONT_SIZE;
        private float _defaultRoundness = 0;

        public bool _focus;
        public Color BaseColor;
        public Color BorderColor;

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

        /// <summary>The numnber of components the conatiner holds.</summary>
        public int Count { get { return _components.Count; } }

        /// <summary>Clears the GÙI container by deleting every component.</summary>
        public void Clear()
        {
            _components.Clear();
        }

        /// <summary>Performs an actions for each element of the GUI.</summary>
        /// <param name="action">Action to perform.</param>
        public void ForEach(Action<Component> action)
        {
            _components.Values.ToList().ForEach(action);
        }

        /// <summary>Checks whether a component exists or not in the container.</summary>
        /// <param name="key">Component to look for.</param>
        /// <returns><see langword="true"/> if exists. <see langword="false"/> otherwise.</returns>
        public bool ContainsComponent(Component component)
        {
            return _components.ContainsValue(component);
        }

        /// <summary>Checks whether a component's key exists or not in the container.</summary>
        /// <param name="key">Key to look for.</param>
        /// <returns><see langword="true"/> if exists. <see langword="false"/> otherwise.</returns>
        public bool ContainsKey(string key)
        {
            return _components.ContainsKey(key);
        }

        /// <summary>Sets the roundness for each component of the GUI.</summary>
        /// <param name="roundness">Roundness to set.</param>
        public void SetDefaultRoundness(float roundness)
        {
            _defaultRoundness = roundness;
            ForEach(component => component.SetDefaultRoundness(_defaultRoundness));
        }

        /// <summary>Sets the default font size for the GUI container.</summary>
        /// <param name="fontSize">Font size to set.</param>
        public void SetDefaultFontSize(int fontSize)
        {
            _defaultFontSize = fontSize;
            ForEach(component =>
            {
                if (component is IWritable writable) writable.SetDefaultFontSize(_defaultFontSize);
            });
        }

        /// <summary>Creates a default instance of <see cref="GuiContainer"/>.</summary>
        public GuiContainer()
        {
            _components = new OrderedDictionary<string, Component>();
            BaseColor = Color.Black;
            BorderColor = Color.White;
            InternalizeContainer();
        }

        /// <summary>Creates a custom instance of <see cref="GuiContainer"/>.</summary>
        /// <param name="colorA">Primary GUI color.</param>
        /// <param name="colorB">Secondary GUI color.</param>
        public GuiContainer(Color colorA, Color colorB)
        {
            _components = new OrderedDictionary<string, Component>();
            BaseColor = colorA;
            BorderColor = colorB;
            InternalizeContainer();
        }

        /// <summary>Adds a GUI component to the container.</summary>
        /// <param name="name">Component name.</param>
        /// <param name="component">Component to add.</param>
        public void Add(string name, Component component)
        {
            // Apply GUI-container's color scheme (if not one already applied)
            if (component.BaseColor.R == 0 && component.BaseColor.G == 0 && component.BaseColor.B == 0) component.BaseColor = BaseColor;
            if (component.BorderColor.R == 0 && component.BorderColor.G == 0 && component.BorderColor.B == 0) component.BorderColor = BorderColor;
            if (component.HoverColor.R == 0 && component.HoverColor.G == 0 && component.HoverColor.B == 0) component.HoverColor = BorderColor;
            // Apply GUI-container's default font size if not already modified
            if (component is IWritable writable) writable.SetDefaultFontSize(_defaultFontSize);
            // Apply GUI-container's default roundness if not already modified
            component.SetDefaultRoundness(_defaultRoundness);
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

        /// <summary>Internalizes a container to the library.</summary>
        private void InternalizeContainer()
        {
            _id = Random.Shared.Next(0, 1000);
            RayGUI._activeContainers.Add(_id, _focus);
        }
    }
}
