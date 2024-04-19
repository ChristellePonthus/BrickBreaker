using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace BrickBreaker
{
    public interface ISceneManager
    {
        void Load(Type sceneType);
    }
    public sealed class SceneManager : ISceneManager
    {
        private Scene _currentScene;
        private Dictionary<Type, Scene> _scenes = new Dictionary<Type, Scene>();

        public SceneManager()
        {
            ServiceLocator.Register<ISceneManager>(this);
        }
        public void Register(Scene scene)
        {
            _scenes.Add(scene.GetType(), scene);
        }
        public void Load(Type sceneType)
        {
            if (_currentScene != null)
            {
                _currentScene.Unload();
                _currentScene = null;
            }
            _currentScene = _scenes[sceneType];
            _currentScene.Load();
        }

        public void Unload(Type sceneType)
        {
            if (_currentScene != null)
            {
                _scenes[sceneType] = null;
            }
        }
        public void Update(GameTime gameTime)
        {
            if (_currentScene != null) _currentScene.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            if (_currentScene != null) _currentScene.Draw(batch);
        }
    }
}
