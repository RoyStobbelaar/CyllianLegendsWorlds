using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CyllianLegendsWorlds.Models.Specifics
{
    /// <summary>
    /// Specific class for a player
    /// </summary>
    public class Player : MovingEntity
    {
        public Texture2D Portrait { get; set; }

        private KeyboardState keys;

        public Player(Game game) : base(game)
        {
            this.Position = new Vector2(200, 200);
            this.SpriteSizeX = 0;
            this.SpriteSizeY = 0;
        }

        public override void Initialize()
        {
            //Load sprite
            this.Portrait = this.Game.Content.Load<Texture2D>("portrait/player1");
            this.Image = this.Game.Content.Load<Texture2D>("sprites/Actor1");

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            //Check keys
            var kbState = Keyboard.GetState();
            var mState = Mouse.GetState();
            var currentVelocity = new Vector2(0, 0);

            //Up pressed
            if (kbState.IsKeyDown(Keys.W))
            {
                currentVelocity.Y += -3;
                this.SpriteSizeY = 3;
            }
            //Left pressed
            if (kbState.IsKeyDown(Keys.A))
            {
                currentVelocity.X += -3;
                this.SpriteSizeY = 1;
            }
            //Down pressed
            if (kbState.IsKeyDown(Keys.S))
            {
                currentVelocity.Y += 3;
                this.SpriteSizeY = 0;
            }
            //Right pressed
            if (kbState.IsKeyDown(Keys.D))
            {
                currentVelocity.X += 3;
                this.SpriteSizeY = 2;
            }

            this.Velocity = currentVelocity;

            keys = kbState;

            //Animate player
            if (this.Velocity != Vector2.Zero)
            {
                if ((this.SpriteSizeX + 1) < this.MaxSpriteSizeX)
                {
                    this.SpriteSizeX++;
                }
                else
                {
                    this.SpriteSizeX = 0;
                }

                //Also, move player if velocity is set
                this.Position += this.Velocity;
            }



            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this._spriteBatch.Begin();
            
            //Source
            Rectangle sourceRect = new Rectangle(SizeX * this.SpriteSizeX, SizeY * SpriteSizeY, SizeX, SizeY);
            //Rect on map
            Rectangle mapRect = new Rectangle((int)this.Position.X, (int)this.Position.Y, SizeX, SizeY);


            this._spriteBatch.Draw(this.Image, mapRect, sourceRect, Color.White);

            this._spriteBatch.End();
        }
    }
}
