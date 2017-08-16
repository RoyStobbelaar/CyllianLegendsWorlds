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
        public DrawableGameComponent ActiveScreen { get; set; }
        public DrawableGameComponent PreviousScreen { get; set; }

        public ScreenManager(Game game) : base(game)
        {
            this.screens = new Stack<DrawableGameComponent>();
        }

        public void SetScreen(DrawableGameComponent newScreen)
        {
            if(screens.Count >= 1)
            {
                this.PreviousScreen = screens.Peek();
            }

            this.screens.Push(newScreen);
            this.ActiveScreen = newScreen;
        }

        public void PopScreen()
        {
            this.screens.Pop();
            if(this.screens.Count > 0)
            {
                this.ActiveScreen = this.screens.Peek();
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

            if (this.ActiveScreen != null)
            {
                this.ActiveScreen.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            
            if(this.ActiveScreen != null)
            {
                this.ActiveScreen.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}
