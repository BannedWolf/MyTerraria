using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Terraria
{
    class Chunk
    {
 
        public Tile[,] Tiles { get; set; }

        public const int CHUNK_SIZE = 25;

        public SpriteBatch SpriteBatch { get; set; }

        public Texture2D[] Texture { get; set; }

        public Vector2 Position { get; set; }
        
        public Vector2 offset { get; set; }

        public Chunk(Texture2D[] texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.Texture = texture;
            this.SpriteBatch = spriteBatch;
            this.Position = position;

            offset = new Vector2(0f, 360f);

            Tiles = new Tile[CHUNK_SIZE, CHUNK_SIZE];

            GenerateChunks();

        }

        public void GenerateChunks()
        {
            for (int x = 0; x < CHUNK_SIZE; x++)
            {
                for (int y = 0; y < CHUNK_SIZE; y++)
                {
                    Vector2 newPosition = new Vector2(Texture[0].Width * x, Texture[0].Height * y);
                    newPosition += Position + offset;

                    Tiles[x, y] = new Tile(Texture[0], newPosition, SpriteBatch);
                }
            }
        }

        public void GenerateNoise()
        {
        }

        public void Draw()
        {
            foreach (var tile in Tiles)
                tile.Draw();
        }
    }

}
