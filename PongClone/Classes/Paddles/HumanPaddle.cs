using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongClone
{
    public class HumanPaddle : Paddle
    {
        public HumanPaddle(Texture2D texture, Vector2 vector, Rectangle screenBounds)
            : base(texture, vector, screenBounds)
        {

        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Velocity = new Vector2(0, -6f);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Velocity = new Vector2(0, 6f);
            }
            else
            {
                Velocity = new Vector2(0, 0);
            }

            base.Update(gameTime, gameObjects);
        }
    }
}
