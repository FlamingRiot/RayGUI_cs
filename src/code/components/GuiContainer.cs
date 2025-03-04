using System.Runtime.InteropServices;
using Raylib_cs;

namespace RayGUI_cs
{
    /// <summary>Represents an instance of a GUI container.</summary>
    public unsafe class GuiContainer
    {
        private OrderedDictionary<string, Component> _components;
        private bool _focus;
        private GCHandle _focusHandle;

        public Color ColorA;
        public Color ColorB;

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

        ~GuiContainer()
        {
            _focusHandle.Free();
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
            RayGUI.DrawGuiContainer([.._components.Values], ref _focus);

            // Check if cursor occupied
            bool check = false;
            for (int i = 0; i < RayGUI._activeContainers.Length; i++) 
            {
                if (*RayGUI._activeContainers[i]) check = true;
            }
            if (!check) Raylib.SetMouseCursor(MouseCursor.Default);
        }

        private void InternalizeContainer()
        {
            fixed (bool* focus = &_focus)
            {
                // Update internal 
                RayGUI._containerCount++;
                bool*[] current = RayGUI._activeContainers;
                bool*[] newArray = new bool*[RayGUI._containerCount];

                // Fill with old references
                current.CopyTo(newArray, 0);
                newArray[RayGUI._containerCount - 1] = focus;
                RayGUI._activeContainers = newArray;
            }
        }
    }
}
