using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace CasseBriques
{
    class SceneGameplay : Scene
    {
        Pad Pad;
        Ball Ball;
        bool BallStick;
        const int nbColums = 11;
        const int nbRows = 20;
        private int[,] Level;
        private List<Brick> lstBricks;

        public SceneGameplay(Game game) : base(game)
        {            
            Ball = new Ball(game.Content.Load<Texture2D>("balle"), Screen);
            Pad = new Pad(game.Content.Load<Texture2D>("raquette"), Screen);
            
            Pad.SetPosition(new Vector2(
                Screen.Width / 2 - Pad.HalfWidth, 
                Screen.Height - Pad.Height));

            Ball.SetPosition(new Vector2(
                Pad.Centre - Ball.HalfWidth, 
                Pad.Position.Y - Pad.Height));

            Ball.Velocity = new Vector2(5, -5);

            BallStick = true;

            Level = new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0},
                {1,0,0,0,0,0,0,0,0,0,0},
                {3,1,0,0,0,0,0,0,0,0,0},
                {3,2,1,0,0,0,0,0,0,0,0},
                {3,2,4,1,0,0,0,0,0,0,0},
                {3,2,4,5,1,0,0,0,0,0,0},
                {3,2,4,5,3,1,0,0,0,0,0},
                {3,2,4,5,3,2,1,0,0,0,0},
                {3,2,4,5,3,2,4,1,0,0,0},
                {3,2,4,5,3,2,4,5,1,0,0},
                {3,2,4,5,3,2,4,5,3,1,0},
                {3,2,4,5,3,2,4,5,3,2,1},
                {7,6,8,9,7,6,8,9,7,6,8}
            };

            lstBricks = new List<Brick>();
            Texture2D textBrick;
            Texture2D[] textBrickAll = new Texture2D[9];
            for (int t = 1; t <= 9; t++)
            {
                textBrickAll[t - 1] = game.Content.Load<Texture2D>("brique_" + t);
            };
            for (int l = 0; l < Level.GetLength(0); l++)
            {
                for (int c = 0; c < Level.GetLength(1); c++)
                {
                    int brickType = Level[l,c];
                    if (brickType != 0)
                    {
                        textBrick = textBrickAll[brickType - 1];
                        Brick brick = new Brick(textBrick, Screen);
                        brick.SetPosition(c * textBrick.Width, l * textBrick.Height);
                        lstBricks.Add(brick);
                    }
                }
            }
        }

        private void LoadLevel(int levelNum, int[,] level)
        {
            for (int l = 0; l < nbRows-1; l++)
            {
                for (int c = 0; c < nbColums-1; c++)
                {
                    Console.WriteLine(Level[l,c]);
                    Level[l,c] = level[l,c];
                }
            }
        }


        public override void Update() 
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                BallStick = false;
            }

            Pad.Update();

            for (int i = lstBricks.Count -1; i >= 0; i--)
            {
                bool collision = false;
                Brick brick = lstBricks[i];
                brick.Update();
                if (brick.isFalling == false)
                {
                    if (brick.BoundingBox.Intersects(Ball.NextPositionX()))
                    {
                        Ball.InverseVelocityX();
                        collision = true;
                    }
                    if (brick.BoundingBox.Intersects(Ball.NextPositionY()))
                    {
                        Ball.InverseVelocityY();
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
                    lstBricks.Remove(brick);
                }
            }

            Ball.Update();

            if (BallStick)
            {
                Ball.SetPosition(Pad.Centre - Ball.HalfWidth, Pad.Position.Y - Pad.Height);
            }

            if (Pad.BoundingBox.Intersects(Ball.BoundingBox))
            {
                Ball.InverseVelocityY();
                Ball.SetPosition(Ball.Position.X, Ball.Position.Y - Ball.Height);
            }

            if (Ball.Position.Y > Screen.Height)
            {
                BallStick = true;
            }

        }

        public override void DrawScene(SpriteBatch batch)
        {
            Pad.Draw(batch);
            Ball.Draw(batch);
            foreach (var brick in lstBricks)
            {
                brick.Draw(batch);
            }
        }
    }
}
