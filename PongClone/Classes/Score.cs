using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongClone
{
    public class Score
    {
        private readonly SpriteFont _font;
        private readonly Rectangle _gameBoundaries;

        public int PlayerScore { get; set; }
        public int ComputerScore { get; set; }

        public Score(SpriteFont font, Rectangle gameBoundaries)
        {
            _font = font;
            _gameBoundaries = gameBoundaries;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var score = PlayerScore + " - " + ComputerScore;
            var xPosition = (_gameBoundaries.Width / 2) - (_font.MeasureString(score).X / 2);
            var position = new Vector2(xPosition, _gameBoundaries.Height - 100);

            spriteBatch.DrawString(_font, score, position, Color.Black);
        }

        public void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (gameObjects.Ball.Location.X + gameObjects.Ball.Width < 0)
            {
                ComputerScore++;
                gameObjects.Ball.AttachTo(gameObjects.PlayerPaddle);
            }
            else if (gameObjects.Ball.Location.X > _gameBoundaries.Width)
            {
                PlayerScore++;
                gameObjects.Ball.AttachTo(gameObjects.ComputerPaddle);
            }
        }
    }
}
