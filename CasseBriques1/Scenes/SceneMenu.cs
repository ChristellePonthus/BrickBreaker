using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BrickBreaker
{
    class SceneMenu : Scene
    {
        public SceneMenu(Game game) : base(game) { }

        public override void Load()
        {
            Console.WriteLine("Load Scene Menu");
            base.Load();
        }
        public override void Update(GameTime gameTime) 
        {
            var inputs = ServiceLocator.Get<IInputs>();
            var sceneManager = ServiceLocator.Get<ISceneManager>();
            if (inputs.IsJustPressed(Keys.Space))
            {
                sceneManager.Load(typeof(SceneGameplay));
            }
            base.Update(gameTime);
        }

        public override void DrawScene(SpriteBatch batch) 
        {
            SpriteFont font = ServiceLocator.Get<IFont>().GetFont();
            batch.DrawString(font, "Menu", new Vector2(2, 2), Color.White);
        }
    }
}
