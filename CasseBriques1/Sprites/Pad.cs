using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Pad : Sprite
    {
        public float Centre 
        {  
            get
            {
                return Position.X + Width / 2;
            }
        }

        public Pad(Texture2D texture, Rectangle screen) : base(texture, screen)
        {
        }

        public override void Update()
        {
            SetPosition(Mouse.GetState().X - (Width / 2), Position.Y);
            if (Position.X < 0)
            {
                SetPosition(0, Position.Y);
            }
            if (Position.X > Screen.Width - Width)
            {
                SetPosition(Screen.Width - Width, Position.Y);
            }
            base.Update();
        }
    }
}
