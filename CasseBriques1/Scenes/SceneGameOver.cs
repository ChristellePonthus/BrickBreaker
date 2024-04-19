using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BrickBreaker
{
    class SceneGameOver : Scene
    {
        public SceneGameOver(Game game) : base(game) { 
        }

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
            if (inputs.IsJustPressed(Keys.Escape))
            {
                sceneManager.Load(typeof(SceneMenu));
            }
            base.Update(gameTime);
        }

        public override void DrawScene(SpriteBatch batch)
        {
            SpriteFont myFont = AssetsManager.mainFont;
            batch.DrawString(myFont, "GAMEOVER", new Vector2(200, 200), Color.White);
            batch.DrawString(myFont, "Press SPACE to play again", new Vector2(150, 250), Color.White);
            batch.DrawString(myFont, "Press ESC to return to the main menu", new Vector2(100, 350), Color.White);
        }
    }
}
