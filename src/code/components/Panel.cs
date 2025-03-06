using Raylib_cs;
namespace RayGUI_cs
{
    /// <summary>Panel component of the library</summary>
    public class Panel : Component
    {
        private int _maxWidth;
        private int _maxHeight;
        private Rectangle _sourceRect;
        private Rectangle _targetRect;

        internal Rectangle SourceRectangle { get { return _sourceRect; } }
        internal Rectangle TargetRectangle { get { return _targetRect; } }

        public int MaxWidth {  get { return _maxWidth; }
            set 
            {
                _maxWidth = value;
                _targetRect.Width = Raymath.Clamp(Width, 0, MaxWidth);
            }
        }
        public int MaxHeight { get { return _maxHeight; }
            set
            {
                _maxHeight = value;
                _targetRect.Height = Raymath.Clamp(Height, 0, MaxHeight);
            }
        }

        /// <summary>Width of the panel.</summary>
        public new int Width { get { return (int)_targetRect.Width; } 
            set 
            { 
                _targetRect.Width = Raymath.Clamp(Math.Abs(value), 0, MaxWidth); 
            }
        }

        /// <summary>Height of the panel.</summary>
        public new int Height
        {
            get { return (int)_targetRect.Height; }
            set
            {
                _targetRect.Height = Raymath.Clamp(Math.Abs(value), 0, MaxHeight);
            }
        }

        /// <summary>Rotation of the panel</summary>
        public float Rotation;

        /// <summary>Texture of the panel</summary>
        public Texture2D Texture;

        /// <summary>Initializes a new instance of a <see cref="Panel"/> object.</summary>
        /// <param name="x">X position of the panel</param>
        /// <param name="y">Y position of the panel</param>
        /// <param name="texture">Displayed image of the panel.</param>
        public Panel(int x, int y, Texture2D texture) : base(x, y, texture.Width, texture.Height)
        {
            Texture = texture;

            _sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);
            _targetRect = new Rectangle(x, y, texture.Width, texture.Height);

            MaxWidth = Width;
            MaxHeight = Height;
            Width = (int)_targetRect.Width;
            Height = (int)_targetRect.Height;
        }

        /// <summary>Initializes a new instance of a <see cref="Panel"/> object.</summary>
        /// <param name="x">X position of the panel</param>
        /// <param name="y">Y position of the panel</param>
        /// <param name="scale">Scale of the panel</param>
        /// <param name="rotation">Rotation of the panel</param>
        /// <param name="texture">Displayed image of the panel.</param>
        public Panel(int x, int y, float rotation, float scale, Texture2D texture) : base(x, y, texture.Width, texture.Height)
        {
            Rotation = rotation;
            Texture = texture;

            _sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);
            _targetRect = new Rectangle(x, y, texture.Width * scale, texture.Height * scale);

            MaxWidth = Width;
            MaxHeight = Height;
            Width = (int)_targetRect.Width;
            Height = (int)_targetRect.Height;
        }
    }
}