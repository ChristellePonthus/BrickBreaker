using Microsoft.Xna.Framework;

namespace CasseBriques
{
    public sealed class Screen
    {
        private GraphicsDeviceManager _graphicsDeviceManager;
        public Screen(GraphicsDeviceManager graphicsDeviceManager)
        {
            _graphicsDeviceManager = graphicsDeviceManager;
        }
        public float Width => _graphicsDeviceManager.PreferredBackBufferWidth;
        public float Height => _graphicsDeviceManager.PreferredBackBufferHeight;

        public Vector2 Center => new Vector2(Width * .5f, Height * .5f);
    }
}
