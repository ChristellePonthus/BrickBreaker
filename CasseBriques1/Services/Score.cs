using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrickBreaker
{
    public interface IServiceScore
    {
        void Add(int points);
        int Get();
    }

    public class Score : IServiceScore
    {
        private int _points;

        public Score()
        {
            _points = 0;
            ServiceLocator.Register<IServiceScore>(this);
        }

        public void Add(int points)
        {
            _points += points;
        }
        public int Get()
        {
            return _points;
        }
        public void Display(SpriteBatch batch)
        {
            SpriteFont myFont = AssetsManager.mainFont;
            batch.DrawString(myFont, "Score : " + Get().ToString(), new Vector2(2, 2), Color.White);
        }
    }
}