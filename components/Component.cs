using Raylib_cs;

namespace RayGUI_cs
{
    /// <summary>Base 2D component of the library</summary>
    public abstract class Component
    {
        //------------------------------------------------------------------------------------
        // Private attributes at the core of the components
        //------------------------------------------------------------------------------------

        private int x;
        private int y;

        private int width;
        private int height;

        private string tag;

        /// <summary>Base color of the component</summary>
        public Color BaseColor;

        /// <summary>Border color of the component</summary>
        public Color BorderColor;

        /// <summary>Hover color of the component</summary>
        public Color HoverColor;

        /// <summary>X Position of the component</summary>
        public int X { get { return x; } set { x = Math.Abs(value); } }

        /// <summary>Y Position of the component</summary>
        public int Y { get { return y; } set { y = Math.Abs(value); } }

        /// <summary>Width the component</summary>
        public int Width { get { return width; } set { width = Math.Abs(value); } }

        /// <summary>Height of the component</summary>
        public int Height { get { return height; } set { height = Math.Abs(value); } }

        /// <summary>Tag of the component</summary>
        public string Tag { get { return tag; } 
            set 
            {
                if (value.Length > RayGUI.MAX_TAG_LENGTH) throw new ArgumentException("Tag size is above 25 characters");
                else tag = value;
            } 
        }

        /// <summary>Initializes a new instance of the <see cref="Component"/> class.</summary>
        /// <param name="x">X Position of the component</param>
        /// <param name="y">Y Position of the component</param>
        /// <param name="width">Width of the component</param>
        /// <param name="height">Height of the component</param>
        internal Component(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            tag = "";

            BaseColor = RayGUI.BaseColor;
            BorderColor = RayGUI.BorderColor;
            HoverColor = RayGUI.BorderColor;
        }

        /// <summary>Initializes a new instance of the <see cref="Component"/> class.</summary>
        /// <param name="x">X Position of the component</param>
        /// <param name="y">Y Position of the component</param>
        /// <param name="width">Width of the component</param>
        /// <param name="height">Height of the component</param>
        /// <param name="tag">Tag of the component</param>
        public Component(int x, int y, int width, int height, string tag)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;

            this.tag = "";
            Tag = tag;

            BaseColor = RayGUI.BaseColor;
            BorderColor = RayGUI.BorderColor;
            HoverColor = RayGUI.BorderColor;
        }

        /// <summary>Returns a <see langword="string"/> containg informations about the instance.</summary>
        /// <returns><see langword="string"/></returns>
        public override string ToString()
        {
            return $"Position: <{X},{Y}> Size: <{Width} {Height}>";
        }

        /// <summary>Returns a hash code based on the combined informations of the instance.</summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            
            hash.Add(X);
            hash.Add(Y);
            hash.Add(Width);
            hash.Add(Height);
            hash.Add(Tag);

            return hash.ToHashCode();
        }
    }
}