using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Terraria
{
    class Cursor
    {
        public Texture2D CursorTexture { get; set; }

        public Vector2 RenderedFrame { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle FrameRendered;

        public Cursor(Texture2D texture)
        {
            CursorTexture = texture;

            FrameRendered = new Rectangle(0, 0, 8, 8);
        }

        public void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();

            Position = new Vector2(state.X, state.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CursorTexture, Position, FrameRendered, Color.White);
        }
    }
}
