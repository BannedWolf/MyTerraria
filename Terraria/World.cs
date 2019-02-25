using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
    class World
    {
        public float[,] noise { get; private set; }

        private Random Random;

        public Chunk[,] Chunks { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public Texture2D[] Texture { get; set; }

        public Vector2 Position { get; set; }

        public int WorldSize { get; set; }

        public const int CHUNK_TILE_SIZE = 400;

        public int itrY { get; set; }

        public int itrX { get; set; }

        public int amount { get; set; }

        public const int MaxDepth = 4;

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

            noise = Simplex.Noise.Calc2D(WorldSize * Chunk.CHUNK_SIZE, MaxDepth * Chunk.CHUNK_SIZE, 0.08f);

            GenerateBasicWorld();
            SetByNoise();
        }

        public void GenerateBasicWorld()
        {
            for (int x = 0; x < WorldSize; x++)
            {
                for (int y = 0; y < MaxDepth; y++) //4 chunks deep or 100 tiles
                {
                    Position = new Vector2(CHUNK_TILE_SIZE * x, CHUNK_TILE_SIZE * y);
                    Chunks[x, y] = new Chunk(Texture, Position, SpriteBatch);
                }
            }
        }

        public void SetByNoise()
        {
            for (int x = 0; x < WorldSize; x++)
            {
                for (int y = 0; y < MaxDepth; y++)
                {
                    foreach (var tile in Chunks[x, y].Tiles)
                    {
                        //System.Diagnostics.Trace.WriteLine(itrX + " " + itrY);
                        //System.Diagnostics.Trace.WriteLine(noise);

                        if(itrX > Chunk.CHUNK_SIZE)
                        {
                            itrX = 0;
                            ++itrY;
                            if (itrY > Chunk.CHUNK_SIZE)
                                itrY = 0;
                        }

                        if (noise[itrX, itrY] >= 0f && noise[itrX, itrY] <= 85f)
                        {
                            tile.Texture = Texture[4];
                        }
                        else
                        {
                            tile.Texture = Texture[0];
                        }
                        ++itrX;
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