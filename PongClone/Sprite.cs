using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongClone
{
    public abstract class Sprite
    {
        protected Texture2D _texture;
        protected Vector2 _location;
        protected Vector2 _velocity = Vector2.Zero;

        public Sprite(Texture2D texture, Vector2 location)
        {
            this._texture = texture;
            this._location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            _location += _velocity;

            CheckBounds();
        }

        protected abstract void CheckBounds();
    }
}
