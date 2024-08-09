using Raylib_cs;
namespace RayGUI_cs
{
    public class Panel
    {
        /// <summary>
        /// X coordinate of the panel
        /// </summary>
        public int X;

        /// <summary>
        /// Y coordinate of the panel
        /// </summary>
        public int Y;

        /// <summary>
        /// Panel scale
        /// </summary>
        public float Scale;

        /// <summary>
        /// Panel rotation
        /// </summary>
        public float Rotation;

        /// <summary>
        /// Panel textures
        /// </summary>
        public Texture2D Texture;

        /// <summary>
        /// Panel tag
        /// </summary>
        public string Tag;

        public Panel(int X, int Y, float Scale, float Rotation, Texture2D Texture, string Tag)
        {
            this.X = X; 
            this.Y = Y; 
            this.Scale = Scale;
            this.Rotation = Rotation;
            this.Texture = Texture;
            this.Tag = Tag;
        }
    }
}
