using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Terraria
{
    class Chunk
    {
        private float NoiseValues { get; set; }

        public Tile[,] Tiles { get; set; }

        public const int CHUNK_SIZE = 25;

        public SpriteBatch SpriteBatch { get; set; }

        public Texture2D[] Texture { get; set; }

        public Vector2 Position { get; set; }

        private Random Random;

        public Chunk(Texture2D[] texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.Texture = texture;
            this.SpriteBatch = spriteBatch;
            this.Position = position;

            Random = new Random();

            Simplex.Noise.Seed = Random.Next();

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
                    newPosition += Position;

                    NoiseValues = Simplex.Noise.CalcPixel2D(x, y, 0.136f);

                    if (NoiseValues >= 0f && NoiseValues <= 120f)
                        Tiles[x, y] = new Tile(Texture[0], newPosition, SpriteBatch);
                    else if (NoiseValues >= 121f && NoiseValues <= 190f)
                        Tiles[x, y] = new Tile(Texture[1], newPosition, SpriteBatch);
                    else if (NoiseValues >= 170f && NoiseValues <= 199f)
                        Tiles[x, y] = new Tile(Texture[2], newPosition, SpriteBatch);
                       else if (NoiseValues >= 236f && NoiseValues <= 255f)
                        Tiles[x, y] = new Tile(Texture[3], newPosition, SpriteBatch);
                    else
                        Tiles[x, y] = new Tile(Texture[4], newPosition, SpriteBatch);
                }
            }
        }

        public void Draw()
        {
            foreach (var tile in Tiles)
                tile.Draw();
        }
    }

}
