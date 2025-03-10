using Raylib_cs;

namespace RayGUI_cs
{
    /// <summary>Base 2D component of the library</summary>
    public abstract class Component
    {
        //------------------------------------------------------------------------------------
        // Private attributes at the core of the components
        private const float DEFAULT_ROUNDNESS = 0.25f;
        private float _roundness;

        internal Rectangle Rectangle;
        internal bool LightFocus;

        /// <summary>Base color of the component</summary>
        public Color BaseColor;

        /// <summary>Border color of the component</summary>
        public Color BorderColor;

        /// <summary>Hover color of the component</summary>
        public Color HoverColor;

        /// <summary>X Position of the component</summary>
        public int X { get { return (int)Rectangle.X; } set { Rectangle.X = Math.Abs(value); } }

        /// <summary>Y Position of the component</summary>
        public int Y { get { return (int)Rectangle.Y; } set { Rectangle.Y = Math.Abs(value); } }

        /// <summary>Width the component</summary>
        public int Width { get { return (int)Rectangle.Width; } set { Rectangle.Width = Math.Abs(value); } }

        /// <summary>Height of the component</summary>
        public int Height { get { return (int)Rectangle.Height; } set { Rectangle.Height = Math.Abs(value); } }

        /// <summary>Defines the roundness of the component's render rectangle.</summary>
        public float Roundness { get { return _roundness; } set { _roundness = value; } }

        /// <summary>Initializes a new instance of the <see cref="Component"/> class.</summary>
        /// <param name="x">X Position of the component</param>
        /// <param name="y">Y Position of the component</param>
        /// <param name="width">Width of the component</param>
        /// <param name="height">Height of the component</param>
        internal Component(int x, int y, int width, int height)
        {
            //_roundness = DEFAULT_ROUNDNESS;
            X = x;
            Y = y;
            Width = width;
            Height = height;

            LightFocus = false;
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

            return hash.ToHashCode();
        }
    }
}