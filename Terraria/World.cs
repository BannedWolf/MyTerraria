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

        public Vector2 Axis { get; set; }

        public World(SpriteBatch spriteBatch, Texture2D[] texture, int worldSize)
        {
            this.SpriteBatch = spriteBatch;
            this.Texture = texture;

            Random = new Random();
            Simplex.Noise.Seed = Random.Next();

            WORLD_SIZE = worldSize;

            Chunks = new Chunk[WORLD_SIZE, WORLD_SIZE];

            GenerateBasicWorld();
            SetTiles();
        }

        public void GenerateBasicWorld()
        {
            for (int x = 0; x < WORLD_SIZE; x++)
            {
                for (int y = 0; y < WORLD_SIZE; y++)
                {
                    Position = new Vector2(CHUNK_TILE_SIZE * x, CHUNK_TILE_SIZE * y);
                    Chunks[x, y] = new Chunk(Texture, Position, SpriteBatch);
                }
            }
        }

        public void SetTiles()
        {
            foreach(var chunk in Chunks)
            {
                foreach (var tile in chunk.Tiles)
                {
                    NoiseValues = Simplex.Noise.CalcPixel2D((int)Axis.X, (int)Axis.Y, 0.1f);

                    if (NoiseValues >= 0f && NoiseValues <= 56.12f)
                        tile.Texture = this.Texture[3];
                    else if (NoiseValues >= 57f && NoiseValues <= 87f)
                        tile.Texture = this.Texture[1];
                    else if (NoiseValues >= 88f && NoiseValues <= 125f)
                        tile.Texture = this.Texture[2];
                    else if (NoiseValues >= 126f && NoiseValues <= 135f)
                        tile.Texture = this.Texture[4];
                    else
                        tile.Texture = this.Texture[0];

                    Axis += new Vector2(0, 1);
                }
                Axis += new Vector2(1, 0);
            }
        }

        public void Draw()
        {
            foreach (var chunk in Chunks)
                chunk.Draw();
        }
    }
}