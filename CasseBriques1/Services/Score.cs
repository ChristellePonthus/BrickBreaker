using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

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
            IFont fontServ = ServiceLocator.Get<IFont>();
            if (fontServ != null)
            {
                SpriteFont font = fontServ.GetFont();
                batch.DrawString(font, "Score : " + Get().ToString(), new Vector2(1, 1), Color.White);
            }
        }
    }
}