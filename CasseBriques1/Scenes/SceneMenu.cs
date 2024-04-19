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
            SpriteFont myFont = AssetsManager.mainFont;
            batch.DrawString(myFont, "Menu", new Vector2(200, 200), Color.White);
            batch.DrawString(myFont, "Press SPACE to play", new Vector2(100, 250), Color.White);
        }
    }
}
