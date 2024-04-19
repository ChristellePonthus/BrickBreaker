using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BrickBreaker
{
    public class AssetsManager
    {
        public static SpriteFont mainFont {  get; private set; }
        public static void FontLoad(ContentManager cm)
        {
            mainFont = cm.Load<SpriteFont>("PixelFont");
        }
    }
}
