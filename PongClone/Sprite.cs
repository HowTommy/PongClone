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

        public Vector2 Velocity = Vector2.Zero;
        
        public Vector2 Location;
        public int Width
        {
            get
            {
                return _texture.Width;
            }
        }

        public Sprite(Texture2D texture, Vector2 location)
        {
            this._texture = texture;
            Location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Location, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            Location += Velocity;

            CheckBounds();
        }

        protected abstract void CheckBounds();
    }
}
