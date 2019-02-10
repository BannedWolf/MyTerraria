using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
    class World 
    {
        private float NoiseValues { get; set; }

        private Random Random;

        public Chunk[,] Chunks { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public Texture2D[] Texture { get; set; }

        public Vector2 Position { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public const int CHUNK_TILE_SIZE = 400;

        public static int WORLD_SIZE;

        public World(SpriteBatch spriteBatch, Texture2D[] texture, int worldSize)
        {
            this.SpriteBatch = spriteBatch;
            this.Texture = texture;

            Random = new Random();
            Simplex.Noise.Seed = Random.Next();

            WORLD_SIZE = worldSize;

            Chunks = new Chunk[WORLD_SIZE, WORLD_SIZE];

            GenerateBasicWorld();
        }

        public void GenerateBasicWorld()
        {
            for (int x = 0; x < WORLD_SIZE; x++)
            {
                for (int y = 0; y < WORLD_SIZE; y++)
                {
                    Position = new Vector2(CHUNK_TILE_SIZE * x, CHUNK_TILE_SIZE * y);
                    Chunks[x, y] = new Chunk(Texture, Position, SpriteBatch);

                    foreach (var tile in Chunks[x, y].Tiles)
                    {
                        NoiseValues = Simplex.Noise.CalcPixel2D(x, y, 0.1f);

                        if (NoiseValues >= 0f && NoiseValues <= 120f)
                            tile.Texture = this.Texture[0];
                        else if (NoiseValues >= 120f && NoiseValues <= 157f)
                            tile.Texture = this.Texture[1];
                        else
                            tile.Texture = this.Texture[3];
                    }
                }
            }
        }

        public void Draw()
        {
            foreach (var chunk in Chunks)
                chunk.Draw();
        }
    }
}
