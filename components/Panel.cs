using Raylib_cs;
namespace RayGUI_cs
{
    public class Panel : Component
    {
        /// <summary>
        /// Panel scale
        /// </summary>
        private float scale;
        /// <summary>
        /// Panel rotation
        /// </summary>
        private float rotation;
        /// <summary>
        /// Panel textures
        /// </summary>
        private Texture2D texture;
        /// <summary>
        /// Panel scale
        /// </summary>
        public float Scale { get { return scale; } set { scale = value; } }
        /// <summary>
        /// Panel rotation
        /// </summary>
        public float Rotation { get { return rotation; } set { rotation = value; } }
        /// <summary>
        /// Panel texture
        /// </summary>
        public Texture2D Texture { get { return texture; } set { texture = value; } }
        /// <summary>
        /// Panel constructor
        /// </summary>
        /// <param name="x">Panel X position</param>
        /// <param name="y">Panel Y position</param>
        /// <param name="scale">Panel scale</param>
        /// <param name="rotation">Panel rotation</param>
        /// <param name="texture">Panel texture</param>
        public Panel(int x, int y, float scale, float rotation, Texture2D texture) : base(x, y, (int)(texture.Width * scale), (int)(texture.Height * scale))
        {
            this.scale = scale;
            this.rotation = rotation;
            this.texture = texture;
            this.Tag = "";
        }
        /// <summary>
        /// Panel constructor
        /// </summary>
        /// <param name="x">Panel X position</param>
        /// <param name="y">Panel Y position</param>
        /// <param name="scale">Panel scale</param>
        /// <param name="rotation">Panel rotation</param>
        /// <param name="texture">Panel texture</param>
        /// <param name="tag">Panel tag</param>
        public Panel(int x, int y, float scale, float rotation, Texture2D texture, string tag) : base(x, y, (int)(texture.Width * scale), (int)(texture.Height * scale), tag)
        {
            this.scale = scale;
            this.rotation = rotation;
            this.texture = texture;
        }
    }
}