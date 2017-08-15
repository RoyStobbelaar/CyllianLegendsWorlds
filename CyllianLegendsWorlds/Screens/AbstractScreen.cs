using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CyllianLegendsWorlds.Screens
{
    public abstract class AbstractScreen : DrawableGameComponent
    {
        //Each screen has a manager and spritebatch
        public ScreenManager ScreenManager { get; set; }
        public SpriteBatch SpriteBatch { get; set; }

        //Each screen has keys and updates
        protected KeyboardState prevKeyboardState { get; set; }
        protected double timeSinceLastUpdate { get; set; }

        public AbstractScreen(Game game) : base(game)
        {}

        public AbstractScreen(Game game, ScreenManager manager) : base(game)
        {
            this.ScreenManager = manager;
        }
    }
}
