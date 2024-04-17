using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrickBreaker
{
    public class Brick : Sprite
    {
        private bool fall;
        public bool isFalling { get { return fall; } }
        public Brick(Texture2D texture, Rectangle screen) : base(texture, screen)
        {
            fall = false;
        }

        public override void Update()
        {
            if (fall)
            {
                Velocity = new Vector2(Velocity.X, Velocity.Y * 1.10f);
            }
            base.Update();
        }

        public void Fall()
        {
            fall = true;
            Velocity = new Vector2(Velocity.X, 1);
            IServiceScore serviceScore = ServiceLocator.Get<IServiceScore>();
            if(serviceScore != null) serviceScore.Add(10);
        }
    }
}
