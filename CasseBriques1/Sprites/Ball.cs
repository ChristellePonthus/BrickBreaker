using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Ball : Sprite
    {
        public Ball(Texture2D texture, Rectangle screen) : base(texture, screen)
        {
        }

        public override void Update()
        {
            if (Position.X > Screen.Width - Width)
            {
                SetPosition(Screen.Width - Width, Position.Y);
                InverseVelocityX();
            }
            if (Position.X < 0)
            {
                SetPosition(0, Position.Y);
                InverseVelocityX();
            }
            if (Position.Y < 0)
            {
                SetPosition(Position.X, 0);
                InverseVelocityY();
            }
            base.Update();
        }
    }
}
