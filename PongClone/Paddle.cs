using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongClone
{
    public class Paddle : Sprite
    {
        private Rectangle _screenBounds;

        public Paddle(Texture2D texture, Vector2 vector, Rectangle screenBounds)
            : base(texture, vector)
        {
            _screenBounds = screenBounds;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Velocity = new Vector2(0, -5f);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Velocity = new Vector2(0, 5f);
            }
            else
            {
                Velocity = new Vector2(0, 0);
            }

            base.Update(gameTime);
        }

        protected override void CheckBounds()
        {
            Location.Y = MathHelper.Clamp(Location.Y, 0, _screenBounds.Height - _texture.Height);
        }
    }
}
