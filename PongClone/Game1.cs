using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongClone
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private GameObjects _gameObjects;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _gameObjects = new GameObjects();

            var gameBounderies = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);

            var paddleTexture = Content.Load<Texture2D>("paddle");

            _gameObjects.PlayerPaddle = new HumanPaddle(paddleTexture, Vector2.Zero, gameBounderies);

            var computerPaddleLocation = new Vector2(gameBounderies.Width - paddleTexture.Width, 0);

            _gameObjects.ComputerPaddle = new ComputerPaddle(paddleTexture, computerPaddleLocation, gameBounderies, Difficulty.Insane);

            _gameObjects.Ball = new Ball(Content.Load<Texture2D>("ball"), Vector2.Zero, gameBounderies);
            _gameObjects.Ball.AttachTo(_gameObjects.PlayerPaddle);

            _gameObjects.Score = new Score(Content.Load<SpriteFont>("testfont"), gameBounderies);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _gameObjects.PlayerPaddle.Update(gameTime, _gameObjects);
            _gameObjects.ComputerPaddle.Update(gameTime, _gameObjects);
            _gameObjects.Ball.Update(gameTime, _gameObjects);
            _gameObjects.Score.Update(gameTime, _gameObjects);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            _gameObjects.PlayerPaddle.Draw(spriteBatch);
            _gameObjects.ComputerPaddle.Draw(spriteBatch);
            _gameObjects.Ball.Draw(spriteBatch);
            _gameObjects.Score.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
