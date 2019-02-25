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

        Text FPSCounter;

        SpriteFont Font;

        Cursor cursor;

        Texture2D cursorTexture;

        public Terraria()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;

        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Font = Content.Load<SpriteFont>("fonts/emulogic");

            tilesTexture = new Texture2D[5];

            tilesTexture[0] = Content.Load<Texture2D>("textures/tile");
            tilesTexture[1] = Content.Load<Texture2D>("textures/tile_2");
            tilesTexture[2] = Content.Load<Texture2D>("textures/tile_3");
            tilesTexture[3] = Content.Load<Texture2D>("textures/tile_4");
            tilesTexture[4] = Content.Load<Texture2D>("textures/tile_5");

            cursorTexture = Content.Load<Texture2D>("textures/cursor");

            world = new World(spriteBatch, tilesTexture, 10);
            cursor = new Cursor(cursorTexture);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            cursor.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            ShowFPS(gameTime);

            spriteBatch.Begin();
            world.Draw();
            FPSCounter.Draw();
            cursor.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ShowFPS(GameTime gameTime)
        {
            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            FPSCounter = new Text(Font, new Vector2(15, 15), "FPS: " + frameRate, spriteBatch);
        }
    }
}
