using BrickBreaker.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Reflection;

namespace BrickBreaker
{
    public class BrickBreakerGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Inputs _inputs;
        private SceneManager _sceneManager;
        private Screen _screen;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            AssetsManager.FontLoad(Content);

            _sceneManager.Register(new SceneMenu(this));
            _sceneManager.Register(new SceneGameplay(this));
            _sceneManager.Register(new SceneVictory(this));
            _sceneManager.Register(new SceneGameOver(this));
            _sceneManager.Register(new SceneGameBreak(this));
            _sceneManager.Load(typeof(SceneMenu));
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected void UpdateGameplay(GameTime gameTime)
        {
        }

        protected override void Update(GameTime gameTime)
        {
            _sceneManager.Update(gameTime);
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
