using Microsoft.Xna.Framework.Graphics;

namespace BrickBreaker
{
    public interface IFont
    {
        public void SetFont(SpriteFont font);
        public SpriteFont GetFont();
    }
    public class Font : IFont
    {
        SpriteFont mainFont;

        public Font()
        {
            ServiceLocator.Register<IFont>(this);
        }

        public SpriteFont GetFont()
        {
            return mainFont;
        }
        public void SetFont(SpriteFont font)
        {
            mainFont = font;
        }
    }
}
