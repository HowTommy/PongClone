using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongClone
{
    public abstract class Paddle : Sprite
    {
        public Paddle(Texture2D texture, Vector2 vector, Rectangle screenBounds)
            : base(texture, vector, screenBounds)
        {

        }

        protected override void CheckBounds()
        {
            Location.Y = MathHelper.Clamp(Location.Y, 0, _gameBounderies.Height - _texture.Height);
        }
    }
}
