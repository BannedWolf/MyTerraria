using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
    class Sprite
    {
        public Vector2 Position { get; set; }

        public Texture2D Texture { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public Sprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.Position = position;
            this.Texture = texture;
            this.SpriteBatch = spriteBatch;
        }

        public virtual void Draw()
        {
            SpriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
