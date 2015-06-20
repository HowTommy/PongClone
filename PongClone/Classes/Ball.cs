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

        public bool IsAttached
        {
            get
            {
                return _attachedPaddle != null;
            }
        }

        public DateTime ComputerLaunchBallTime { get; set; }

        public Ball(Texture2D texture, Vector2 location, Rectangle gameBounderies)
            : base(texture, location, gameBounderies)
        {

        }

        protected override void CheckBounds()
        {
            if (Location.Y >= (_gameBounderies.Height - _texture.Height) || Location.Y <= 0)
            {
                Velocity = new Vector2(Velocity.X, -Velocity.Y);
            }
        }

        public void AttachTo(Paddle paddle)
        {
            _attachedPaddle = paddle;

            if (paddle is ComputerPaddle)
            {
                ComputerLaunchBallTime = DateTime.UtcNow.AddSeconds(1);
            }

            Velocity = new Vector2(0, 0);
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (_attachedPaddle != null)
            {
                AttachBallToPaddle();
                CheckIfTheBallShouldMove();
            }
            else
            {
                var player = gameObjects.PlayerPaddle;
                var humanPlayerHitbox = new Rectangle(player.BoundingBox.X + player.Width, player.BoundingBox.Y, 0, player.Height);

                var computer = gameObjects.ComputerPaddle;
                var computerHitbox = new Rectangle(computer.BoundingBox.X, computer.BoundingBox.Y, 0, computer.Height);

                if (BoundingBox.Intersects(humanPlayerHitbox))
                {
                    ChangeVelocityOnHit(player);
                }
                else if (BoundingBox.Intersects(computerHitbox))
                {
                    ChangeVelocityOnHit(computer);
                }
            }

            base.Update(gameTime, gameObjects);
        }

        private void ChangeVelocityOnHit(Paddle paddle)
        {
            var y = Velocity.Y;
            if (Velocity.Y > 0 && paddle.Velocity.Y > 0
                || Velocity.Y < 0 && paddle.Velocity.Y < 0)
            {
                y *= 1.06f;
            }
            else if (Velocity.Y > 0 && paddle.Velocity.Y < 0
              || Velocity.Y < 0 && paddle.Velocity.Y > 0)
            {
                y *= -0.97f;
            }
            Velocity = new Vector2(-Velocity.X * 1.03f, y);
        }

        private void CheckIfTheBallShouldMove()
        {

            if (_attachedPaddle is HumanPaddle && Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                LaunchBall();
            }
            else if (_attachedPaddle is ComputerPaddle && DateTime.UtcNow > ComputerLaunchBallTime)
            {
                LaunchBall();
            }
        }

        private void AttachBallToPaddle()
        {
            if (_attachedPaddle is ComputerPaddle)
            {
                Location.X = _attachedPaddle.Location.X - Width;
                Location.Y = _attachedPaddle.Location.Y + _attachedPaddle.Height / 2 - Height / 2;
            }
            else if (_attachedPaddle is HumanPaddle)
            {
                Location.X = _attachedPaddle.Location.X + _attachedPaddle.Width;
                Location.Y = _attachedPaddle.Location.Y + _attachedPaddle.Height / 2 - Height / 2;
            }
        }

        private void LaunchBall()
        {
            var x = _attachedPaddle is ComputerPaddle ? -8f : 8f;

            if (_attachedPaddle.Velocity.Y == 0)
            {
                Random r = new Random();
                int randomGoUpOrDown = r.Next(0, 2) % 1 == 0 ? 1 : -1;
                Velocity = new Vector2(x, randomGoUpOrDown * r.Next(3, 7));
            }
            else
            {
                Velocity = new Vector2(x, _attachedPaddle.Velocity.Y * 0.75f);
            }

            _attachedPaddle = null;
        }
    }
}
