using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
    class World
    {
        public float[,] noises { get; private set; }

        private Random Random;

        public Chunk[,] Chunks { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public Texture2D[] Texture { get; set; }

        public Vector2 Position { get; set; }

        public int WorldSize { get; set; }

        public const int CHUNK_TILE_SIZE = 400;

        public Vector2 Axis { get; set; }

        public World(SpriteBatch spriteBatch, Texture2D[] texture, int worldSize)
        {
            this.SpriteBatch = spriteBatch;
            this.Texture = texture;
            this.WorldSize = worldSize;

            Chunks = new Chunk[WorldSize, WorldSize];

            Random = new Random();
            Simplex.Noise.Seed = Random.Next();

            Axis = new Vector2(0, 0);

            noises = Simplex.Noise.Calc2D(WorldSize * 25, WorldSize * 25, 0.1f);

            GenerateBasicWorld();
            OutputNoise();
        }

        public void GenerateBasicWorld()
        {
            for (int x = 0; x < WorldSize; x++)
            {
                for (int y = 0; y < WorldSize; y++)
                {
                    Position = new Vector2(CHUNK_TILE_SIZE * x, CHUNK_TILE_SIZE * y);
                    Chunks[x, y] = new Chunk(Texture, Position, SpriteBatch);
                }
            }
        }

        public void OutputNoise()
        {

            foreach(var chunk in Chunks)
            {
                foreach(var tile in chunk.Tiles)
                {
                    for (int x = 0; x < WorldSize * 25; x++)
                    {
                        for (int y = 0; y < WorldSize * 25; y++)
                        {
                            System.Diagnostics.Trace.WriteLine(noises[x, y]);

                            if(noises[x, y] >= 15f && noises[x, y] <= 125f)
                            {
                                tile.Texture = Texture[0];
                            }
                            else
                            {
                                tile.Texture = Texture[3];
                            }
                        }
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