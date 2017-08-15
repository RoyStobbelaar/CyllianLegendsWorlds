using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CyllianLegendsWorlds.Screens
{
    public class ScreenManager : DrawableGameComponent
    {

        public Stack<DrawableGameComponent> screens { get; set; }
        public DrawableGameComponent activeScreen { get; set; }
        public DrawableGameComponent previousScreen { get; set; }

        public ScreenManager(Game game) : base(game)
        {
            this.screens = new Stack<DrawableGameComponent>();
        }

        public void SetScreen(DrawableGameComponent newScreen)
        {
            if(screens.Peek() != null)
            {
                this.previousScreen = screens.Peek();
            }

            this.screens.Push(newScreen);
            this.activeScreen = newScreen;
        }

        public void PopScreen()
        {
            this.screens.Pop();
            if(this.screens.Count > 0)
            {
                this.activeScreen = this.screens.Peek();
            }

            //Add to component oid?
        }

        public DrawableGameComponent PeekScreen()
        {
            return this.screens.Peek();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            Console.WriteLine("Update screen manager");

            if (this.activeScreen != null)
            {
                this.activeScreen.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            
            if(this.activeScreen != null)
            {
                this.activeScreen.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}
