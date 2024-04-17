using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public abstract class Sprite
    {
        protected Rectangle Screen;
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        private Texture2D Texture;
        public Rectangle BoundingBox { get; private set; }

        public int Height
        { 
            get 
            { 
                return Texture.Height; 
            }
            private set { }
        }

        public int Width
        { 
            get 
            { 
                return Texture.Width; 
            } 
            private set { }
        }

        public int HalfWidth
        {
            get 
            {
                return Texture.Width / 2;
            }
        }

        public Sprite(Texture2D texture, Rectangle screen)
        {
            Texture = texture;
            Screen = screen;
        }

        public void SetPosition(Vector2 position)
        { 
            Position = position;
        }

        public void SetPosition(float X, float Y)
        {
            Position = new Vector2(X, Y);
        }

        public Rectangle NextPositionX() 
        {
            Rectangle nextPosition = BoundingBox;
            // Déplace le rectangle horizontalement (nextPosition.X = nextPosition.X + Velocity.X) :
            nextPosition.Offset(new Point((int)Velocity.X, 0));
            return nextPosition;
        }
        public Rectangle NextPositionY()
        {
            Rectangle nextPosition = BoundingBox;
            // Déplace le rectangle verticalement :
            nextPosition.Offset(new Point(0, (int)Velocity.Y));
            return nextPosition;
        }

        public void InverseVelocityX()
        {
            Velocity = new Vector2 (-Velocity.X, Velocity.Y);
        }

        public void InverseVelocityY()
        {
            Velocity = new Vector2(Velocity.X, -Velocity.Y);
        }

        public virtual void Update()
        {
            Position += Velocity;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Position, Color.White);
        }

    }
}
