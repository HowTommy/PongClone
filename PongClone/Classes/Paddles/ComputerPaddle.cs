using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongClone
{
    public enum Difficulty
    {
        Easy = 30,
        Medium = 20,
        Hard = 10,
        Insane = 0
    }

    public class ComputerPaddle : Paddle
    {
        private readonly Difficulty _difficulty;

        public ComputerPaddle(Texture2D texture, Vector2 vector, Rectangle screenBounds, Difficulty difficulty)
            : base(texture, vector, screenBounds)
        {
            _difficulty = difficulty;
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (gameObjects.Ball.IsAttached)
            {
                // it goes to the middle
                if (Location.Y < _gameBounderies.Height / 2 - Height / 2)
                {
                    Velocity = new Vector2(0, 6f);
                }
                else if (Location.Y > _gameBounderies.Height / 2 + Height / 2)
                {
                    Velocity = new Vector2(0, -6f);
                }
                else
                {
                    Velocity = new Vector2(0, 0);
                }
            }

            if (gameObjects.Ball.Location.Y + gameObjects.Ball.Height + (int)_difficulty < Location.Y)
            {
                Velocity = new Vector2(0, -6f);
            }
            if (gameObjects.Ball.Location.Y > Location.Y + Height + (int)_difficulty)
            {
                Velocity = new Vector2(0, 6f);
            }

            base.Update(gameTime, gameObjects);
        }
    }
}
