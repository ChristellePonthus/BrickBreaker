using Microsoft.Xna.Framework;

namespace BrickBreaker
{
    public interface IScreen
    {

    }
    public sealed class Screen : IScreen
    {
        private GraphicsDeviceManager _graphicsDeviceManager;
        public Screen(GraphicsDeviceManager graphicsDeviceManager)
        {
            _graphicsDeviceManager = graphicsDeviceManager;
            ServiceLocator.Register<IScreen>(this);
        }
        public float Width => _graphicsDeviceManager.PreferredBackBufferWidth;
        public float Height => _graphicsDeviceManager.PreferredBackBufferHeight;

        public Vector2 Center => new Vector2(Width * .5f, Height * .5f);
    }
}
