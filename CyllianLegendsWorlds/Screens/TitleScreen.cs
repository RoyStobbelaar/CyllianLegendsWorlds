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
    public class TitleScreen : AbstractScreen
    {
        public Texture2D BackgroundImage { get; set; }
        private int selectedItem { get; set; }
        private List<string> options { get; set; }
        private SpriteFont font { get; set; }

        public TitleScreen(Game game, ScreenManager screenManager) : base(game, screenManager)
        {
            options = new List<string>();
            Initialize();
        }

        public override void Initialize()
        {
            //Load
            this.DrawOrder = 1;
            this.SpriteBatch = new SpriteBatch(GraphicsDevice);

            this.BackgroundImage = Game.Content.Load<Texture2D>("backgrounds/title");
            this.font = Game.Content.Load<SpriteFont>("fonts/font1");

            this.options.Add("Start");
            this.options.Add("Load");
            this.options.Add("Options");
            this.options.Add("Exit");

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            timeSinceLastUpdate += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timeSinceLastUpdate > 20)
            {
                var kbState = Keyboard.GetState();
                var mState = Mouse.GetState();

                //Up pressed
                if (kbState.IsKeyDown(Keys.W))
                {
                    if (selectedItem > 0) { selectedItem--; }
                }
                if (kbState.IsKeyDown(Keys.S))
                {
                    if (selectedItem < 3) { selectedItem++; }
                }
                if (kbState.IsKeyDown(Keys.Space))
                {
                    //Go to start screena
                    ScreenManager.SetScreen(new GameScreen(Game, ScreenManager));
                }

                timeSinceLastUpdate = 0;

                prevKeyboardState = kbState;
                base.Update(gameTime);
            }

        }

        public override void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Begin();

            this.SpriteBatch.Draw(this.BackgroundImage, new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height), Color.White);

            //Draw options

            Color color = new Color();

            for(int i = 0; i < options.Count; i++)
            {
                color = Color.Black;
                if(i == selectedItem)
                {
                    color = Color.Red;
                }
                this.SpriteBatch.DrawString(font, options[i], new Vector2(300, 400 + (i * 50)), color);
            }


            this.SpriteBatch.End();

            //base.Draw(gameTime);
        }
    }
}
