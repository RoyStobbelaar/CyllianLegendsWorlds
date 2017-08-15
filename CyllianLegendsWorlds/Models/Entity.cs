using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CyllianLegendsWorlds.Models
{
    /// <summary>
    /// Base class for all the game components, like characters, tiles, etc.
    /// Should have location and image, no collision yet
    /// </summary>
    public abstract class Entity : DrawableGameComponent
    {
        public Vector2 Position { get; set; }

        //Sprite
        public Texture2D Image { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        //Location on the spritefile
        public int SpriteSizeX { get; set; }
        public int SpriteSizeY { get; set; }

        protected SpriteBatch _spriteBatch { get; set; }

        public Entity(Game game) : base(game)
        {
            //Set default values for sprite sizes
            this.SizeX = 48;
            this.SizeY = 48;
        }

        public override void Initialize()
        {
            this._spriteBatch = new SpriteBatch(GraphicsDevice);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        //All divered classes should implements these
        public override void Draw(GameTime gameTime)
        {
            this._spriteBatch.Begin();

            this._spriteBatch.Draw(Image, Position, Color.White);

            base.Draw(gameTime);

            this._spriteBatch.End();
        }
    }
}
