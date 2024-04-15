using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CasseBriques
{
    public abstract class Scene
    {
        protected Game Game;
        public Rectangle Screen {  get; private set; }
        private Texture2D textureFond;
        protected int CamShakeDuration;
        private Random random;

        public Scene(Game game)
        {
            Game = game;
            Screen = game.Window.ClientBounds;
            textureFond = game.Content.Load<Texture2D>("fond_1");
            random = new Random();
        }

        public abstract void Update();
        public abstract void DrawScene(SpriteBatch batch);
        public void Draw(SpriteBatch batch) 
        {
            batch.Begin();
            batch.Draw(textureFond, new Vector2(0, 0), Color.White);
            batch.End();

            if (CamShakeDuration > 0)
            {
                int decalage = random.Next(-2, 2);
                batch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Matrix.CreateTranslation(decalage, decalage, 0));
                CamShakeDuration--;
            }
            else batch.Begin();
            DrawScene(batch);
            batch.End();
        }
    }
}
