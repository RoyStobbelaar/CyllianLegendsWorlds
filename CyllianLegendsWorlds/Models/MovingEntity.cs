using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CyllianLegendsWorlds.Models
{
    /// <summary>
    /// Base class for everything that can move (on the world map~!), player, enemies, npc's and such
    /// </summary>
    public abstract class MovingEntity : Entity
    {
        public int MaxSpriteSizeX, MaxSpriteSizeY;
        public Vector2 Velocity { get; set; }

        public MovingEntity(Game game) : base(game)
        {
            this.MaxSpriteSizeX = SpriteSizeX + 3;
            this.MaxSpriteSizeY = SpriteSizeY + 3;
            this.Velocity = new Vector2(0, 0);
        }

        public override void Initialize()
        {
            base.Initialize();
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
