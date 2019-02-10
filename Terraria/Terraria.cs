using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Terraria
{
    public class Terraria : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        World world;

        Texture2D[] tilesTexture;
        
        public Terraria()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            tilesTexture = new Texture2D[5];

            tilesTexture[0] = Content.Load<Texture2D>("textures/tile");
            tilesTexture[1] = Content.Load<Texture2D>("textures/tile_2");
            tilesTexture[2] = Content.Load<Texture2D>("textures/tile_3");
            tilesTexture[3] = Content.Load<Texture2D>("textures/tile_4");
            tilesTexture[4] = Content.Load<Texture2D>("textures/tile_5");

            world = new World(spriteBatch, tilesTexture, 5);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            world.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
