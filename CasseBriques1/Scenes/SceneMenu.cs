using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBriques
{
    class SceneMenu : Scene
    {
        SpriteFont MenuFont;
        public SceneMenu(Game game) : base(game)
        {
            MenuFont = Game.Content.Load<SpriteFont>("PixelFont");
        }

        public override void Update() { }

        public override void DrawScene(SpriteBatch batch) 
        {
            batch.DrawString(MenuFont, "Menu", new Vector2(2, 2), Color.White);
        }
    }
}
