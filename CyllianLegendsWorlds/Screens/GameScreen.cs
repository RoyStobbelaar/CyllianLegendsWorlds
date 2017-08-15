using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CyllianLegendsWorlds.Screens
{
    public class GameScreen : AbstractScreen
    {
        public GameScreen(Game game, ScreenManager manager) : base(game, manager)
        {
            Initialize();
        }

        public override void Initialize()
        {
            //Load
            this.DrawOrder = 1;
            this.SpriteBatch = new SpriteBatch(GraphicsDevice);

            base.Initialize();

            //Create map and stuff
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
