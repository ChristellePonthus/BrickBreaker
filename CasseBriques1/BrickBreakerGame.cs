using BrickBreaker.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace BrickBreaker
{
    public class BrickBreakerGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Inputs _inputs;
        private SceneManager _sceneManager;
        private Screen _screen;
        private Assets _assets;
        Font myFonts;
        SceneMenu MySceneMenu;
        SceneGameplay MySceneGameplay;
        Scene CurrentScene;


        public BrickBreakerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 528;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            _screen = new Screen(_graphics);
            _inputs = new Inputs();
            _sceneManager = new SceneManager();
            _assets = new Assets(Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _sceneManager.Register(new SceneMenu(this));
            _sceneManager.Register(new SceneGameplay(this));


            _sceneManager.Load(typeof(SceneMenu));

            myFonts = new Font();
            SpriteFont fontGame = Content.Load<SpriteFont>("PixelFont");
            myFonts.SetFont(fontGame);


            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText("Levels/Level_1.json")));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(LevelJSON));
            LevelJSON level1 = (LevelJSON)ser.ReadObject(stream);
            Console.WriteLine("Test : " + level1);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _sceneManager.Update(gameTime);
            if (_inputs.IsJustPressed(Keys.Space))
            {
                CurrentScene = MySceneGameplay;
            }
            _inputs.UpdateKeyboardState();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _sceneManager.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
