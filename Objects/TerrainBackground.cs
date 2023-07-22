using Mastery.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mastery.Objects
{
    public class TerrainBackground : BaseGameObject
    {
        private const float SCROLLING_SPEED = 2.0f;

        public TerrainBackground(Texture2D texture)
        {
            _texture = texture;
            _position = Vector2.Zero;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var viewport = spriteBatch.GraphicsDevice.Viewport;

            var sourceRectangle = new Rectangle(0, 0, _texture.Width, _texture.Height);

            for (int i = -1; i < viewport.Height / _texture.Height + 1; i++)
            {
                var y = (int)_position.Y + i * _texture.Height;

                for (int j = 0; j < viewport.Width / _texture.Width + 1; j++)
                {
                    var x = (int)_position.X + j * _texture.Width;

                    var destRectangle = new Rectangle(x, y, _texture.Width, _texture.Height);
                    spriteBatch.Draw(_texture, destRectangle, sourceRectangle, Color.White);
                }
            }

            _position.Y = (int)(_position.Y + SCROLLING_SPEED) % _texture.Height;
        }
    }
}
