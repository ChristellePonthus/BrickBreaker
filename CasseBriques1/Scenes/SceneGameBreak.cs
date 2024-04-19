using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BrickBreaker.Scenes
{
    public class SceneGameBreak : Scene
    {
        public SceneGameBreak(Game game) : base(game)
        {
        }

        public override void Update(GameTime gameTime)
        {
            var inputs = ServiceLocator.Get<IInputs>();
            var sceneManager = ServiceLocator.Get<ISceneManager>();
            if (inputs.IsJustPressed(Keys.Space))
            {
                sceneManager.Load(typeof(SceneGameplay));
            }
            if (inputs.IsPressed(Keys.Escape))
            {
                sceneManager.Load(typeof(SceneMenu));
            }

            base.Update(gameTime);
        }

        public override void DrawScene(SpriteBatch batch)
        {
            SpriteFont myFont = AssetsManager.mainFont;
            batch.DrawString(myFont, "Do you want to return to Menu? (press ESC)", new Vector2(200, 200), Color.White);
            batch.DrawString(myFont, "Or continue the game? (press SPACE)", new Vector2(200, 250), Color.White);
        }
    }
}
