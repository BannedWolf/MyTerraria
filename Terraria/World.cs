using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
    class World
    {
        public float noise { get; private set; }

        private Random Random;

        public Chunk[,] Chunks { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public Texture2D[] Texture { get; set; }

        public Vector2 Position { get; set; }

        public int WorldSize { get; set; }

        public const int CHUNK_TILE_SIZE = 400;

        public int itrY { get; set; }

        public int itrX { get; set; }

        public World(SpriteBatch spriteBatch, Texture2D[] texture, int worldSize)
        {
            this.SpriteBatch = spriteBatch;
            this.Texture = texture;
            this.WorldSize = worldSize;

            itrX = 0;
            itrY = 0;

            Chunks = new Chunk[WorldSize, WorldSize];

            Random = new Random();
            Simplex.Noise.Seed = Random.Next();

            GenerateBasicWorld();
            SetByNoise();
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

        public void SetByNoise()
        {
            foreach (var chunk in Chunks)
            {
                foreach (var tile in chunk.Tiles)
                {
                    if(itrY > (Chunk.CHUNK_SIZE * WorldSize) - 1)
                    {
                        itrY = 0;
                        ++itrX;
                    }

                    noise = Simplex.Noise.CalcPixel2D(itrX, itrY, 0.1f);

                    //System.Diagnostics.Trace.WriteLine(itrX + " " + itrY);
                    System.Diagnostics.Trace.WriteLine(noise);

                    if ((noise >= 0f && noise <= 65f) || (noise >= 67f && noise <= 69f))
                    {
                        tile.Texture = Texture[4];
                    }
                    else
                    {
                        tile.Texture = Texture[0];
                    }
                    ++itrY;
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