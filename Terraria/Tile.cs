using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
    enum TileType
    {
        NONE,
        GRASS,
        ROCK,
    }

    class Tile : Sprite
    {
        public TileType TileType { get; set; }

        public Tile(Texture2D texture, Vector2 position, SpriteBatch spriteBatch) : base(texture, position, spriteBatch)
        {
        }
    }
}
