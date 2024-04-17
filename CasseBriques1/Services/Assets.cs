using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BrickBreaker
{
    public interface IAssets
    {
        public T Get<T>(string name);
    }
    public class Assets : IAssets
    {
        private Dictionary<string, object> _assets = new Dictionary<string, object>();
        private ContentManager _contentManager;

        public Assets(ContentManager contentManager)
        {
            _contentManager = contentManager;
            ServiceLocator.Register<IAssets>(this);
        }

        public void Load<T>(string name)
        {
            T asset = _contentManager.Load<T>(name);
            _assets[name] = asset;
        }

        public T Get<T>(string name)
        {
            return (T)_assets[name];
        }
    }
}
