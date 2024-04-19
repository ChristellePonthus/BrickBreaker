using BrickBreaker.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace BrickBreaker
{
    class SceneGameplay : Scene
    {
        Level level;
        Pad pad;
        Ball ball;
        Vortex vortex1;
        Vortex vortex2;
        private int _nbVortex;
        bool ballStick;
        private List<Brick> _lstBricks;
        private readonly Score _score = new Score();
        private int _timer = 3000;

        public SceneGameplay(Game game) : base(game)
        {
            level = new Level(1);

            ball = new Ball(game.Content.Load<Texture2D>("balle"), Screen);
            pad = new Pad(game.Content.Load<Texture2D>("raquette"), Screen);

            vortex1 = new Vortex(game.Content.Load<Texture2D>("vortex"), Screen);
            vortex1.SetPosition(new Vector2(Screen.Width - 50,20));
            vortex2 = new Vortex(game.Content.Load<Texture2D>("vortex"), Screen);
            vortex2.SetPosition(new Vector2(150,Screen.Height - 200));

            pad.SetPosition(new Vector2(
                Screen.Width / 2 - pad.HalfWidth, 
                Screen.Height - pad.Height));

            ball.SetPosition(new Vector2(
                pad.Centre - ball.HalfWidth, 
                pad.Position.Y - pad.Height));

            ball.Velocity = new Vector2(5, -5);

            ballStick = true;

            _lstBricks = new List<Brick>();
            Texture2D textBrick;
            Texture2D[] textBrickAll = new Texture2D[9];
            for (int t = 1; t <= 9; t++)
            {
                textBrickAll[t - 1] = game.Content.Load<Texture2D>("brique_" + t);
            };

            for (int l = 0; l < level.levData.GetLength(0); l++)
            {
                for (int c = 0; c < level.levData.GetLength(1); c++)
                {
                    int brickType = level.levData[l, c];
                    if (brickType != 0)
                    {
                        textBrick = textBrickAll[brickType - 1];
                        Brick brick = new Brick(textBrick, Screen);
                        brick.SetPosition(c * textBrick.Width, l * textBrick.Height);
                        _lstBricks.Add(brick);
                    }
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            /*_timer -= 1;*/
            var inputs = ServiceLocator.Get<IInputs>();
            var sceneManager = ServiceLocator.Get<ISceneManager>();
            if (inputs.IsJustPressed(Keys.Enter))
            {
                sceneManager.Load(typeof(SceneGameBreak));
            }
            base.Update(gameTime);
            
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                ballStick = false;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                ballStick = false;
            }

            pad.Update();

            for (int i = _lstBricks.Count -1; i >= 0; i--)
            {
                bool collision = false;
                Brick brick = _lstBricks[i];
                brick.Update();
                if (brick.isFalling == false)
                {
                    if (brick.BoundingBox.Intersects(ball.NextPositionX()))
                    {
                        ball.InverseVelocityX();
                        collision = true;
                    }
                    if (brick.BoundingBox.Intersects(ball.NextPositionY()))
                    {
                        ball.InverseVelocityY();
                        collision = true;
                    }
                    if (collision) 
                    {
                        brick.Fall();
                        CamShakeDuration = 10;
                    }
                }
                if (brick.Position.Y > Screen.Height)
                {
                    _lstBricks.Remove(brick);
                }
            }

            for (int i = _nbVortex - 1; i >= 0; i--)
            {
                bool collision = false;
                if (vortex1.BoundingBox.Intersects(ball.NextPositionX()) || vortex1.BoundingBox.Intersects(ball.NextPositionY()))
                {
                    ball.SetPosition(vortex2.Position);
                    collision = true;
                }
                if (vortex2.BoundingBox.Intersects(ball.NextPositionX()) || vortex2.BoundingBox.Intersects(ball.NextPositionY()))
                {
                    ball.SetPosition(vortex1.Position);
                    collision = true;
                }
                if (collision)
                {
                    CamShakeDuration = 10;
                }
            }


            ball.Update();

            if (ballStick)
            {
                ball.SetPosition(pad.Centre - ball.HalfWidth, pad.Position.Y - pad.Height);
            }

            if (pad.BoundingBox.Intersects(ball.BoundingBox))
            {
                ball.InverseVelocityY();
                ball.SetPosition(ball.Position.X, ball.Position.Y - ball.Height);
            }

            if (ball.Position.Y > Screen.Height)
            {
                ballStick = true;
            }

            if (_lstBricks.Count == 0)
            {
                if (level.levelNum == 1)
                {
                    _lstBricks.Clear();
                    level.levelNum = 2;
                }
                else
                {
                    _lstBricks.Clear();
                    sceneManager.Load(typeof(SceneVictory));
                }
            }else if (_timer == 0)
            {
                _lstBricks.Clear();
                sceneManager.Load(typeof(SceneGameOver));
            }
        }

        public override void DrawScene(SpriteBatch batch)
        {
            SpriteFont font = AssetsManager.mainFont;
            pad.Draw(batch);
            vortex1.Draw(batch);
            vortex2.Draw(batch);
            ball.Draw(batch);

            foreach (var brick in _lstBricks)
            {
                brick.Draw(batch);
            }
            _score.Display(batch);
            batch.DrawString(font, "Timer : " + _timer, new Vector2(2, 25), Microsoft.Xna.Framework.Color.White);
            batch.DrawString(font, "Press ENTER to PAUSE", new Vector2(280, 2), Microsoft.Xna.Framework.Color.White);
        }
    }
}
