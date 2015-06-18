using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongClone
{
    public class Ball : Sprite
    {
        private Paddle _attachedPaddle;

        public Ball(Texture2D texture, Vector2 location)
            : base(texture, location)
        {

        }

        protected override void CheckBounds()
        {

        }

        public void AttachTo(Paddle paddle)
        {
            _attachedPaddle = paddle;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _attachedPaddle != null)
            {
                var newVelocity = new Vector2(7f, _attachedPaddle.Velocity.Y);
                Velocity = newVelocity;

                _attachedPaddle = null;
            }

            if(_attachedPaddle != null) 
            {
                Location.X = _attachedPaddle.Location.X + _attachedPaddle.Width;
                Location.Y = _attachedPaddle.Location.Y;
            }

            base.Update(gameTime);
        }
    }
}
