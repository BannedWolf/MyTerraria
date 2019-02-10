using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
    class Text
    {
        public SpriteBatch SpriteBatch { get; set; }

        public SpriteFont SpriteFont { get; set; }

        public string DrawText{ get; set; }

        public Vector2 Position { get; set; }

        public Text(SpriteFont font, Vector2 position, string text, SpriteBatch spriteBatch)
        {
            this.SpriteFont = font;
            this.Position = position;
            this.DrawText = text;
            this.SpriteBatch = spriteBatch;
        }

        public virtual void Draw()
        {
            SpriteBatch.DrawString(SpriteFont, DrawText, Position, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}
