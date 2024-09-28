using Raylib_cs;
namespace RayGUI_cs
{
    /// <summary>Panel component of the library</summary>
    public class Panel : Component
    {
        /// <summary>Scale of the panel.</summary>
        public float Scale;

        /// <summary>Rotation of the panel</summary>
        public float Rotation;

        /// <summary>Texture of the panel</summary>
        public Texture2D Texture;

        /// <summary>Initializes a new instance of a <see cref="Panel"/> object.</summary>
        /// <param name="x">X position of the panel</param>
        /// <param name="y">Y position of the panel</param>
        /// <param name="scale">Scale of the panel</param>
        /// <param name="rotation">Rotation of the panel</param>
        /// <param name="texture"><see cref="Texture2D"/> of the panel</param>
        public Panel(int x, int y, float scale, float rotation, Texture2D texture) : base(x, y, (int)(texture.Width * scale), (int)(texture.Height * scale))
        {
            Scale = scale;
            Rotation = rotation;
            Texture = texture;
        }

        /// <summary>Initializes a new instance of a <see cref="Panel"/> object.</summary>
        /// <param name="x">X position of the panel</param>
        /// <param name="y">Y position of the panel</param>
        /// <param name="scale">Scale of the panel</param>
        /// <param name="rotation">Rotation of the panel</param>
        /// <param name="texture"><see cref="Texture2D"/> of the panel</param>
        /// <param name="tag">Tag of the panel</param>
        public Panel(int x, int y, float scale, float rotation, Texture2D texture, string tag) : base(x, y, (int)(texture.Width * scale), (int)(texture.Height * scale), tag)
        {
            Scale = scale;
            Rotation = rotation;
            Texture = texture;
        }
    }
}