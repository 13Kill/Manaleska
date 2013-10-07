#region Using Statements
using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Manaleska
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Manaleska : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;
        private Texture2D _lolifront;
        private Texture2D _background;
        private Texture2D _shuttle;
        private Texture2D _earth;

        public Manaleska()
            : base()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = false
            };

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
            // TODO: Add your initialization logic here

            Window.Title = "Manaleska Doriru Impacto Kawaii";

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _lolifront = Content.Load<Texture2D>("large");
            _background = Content.Load<Texture2D>("background");
            _shuttle = Content.Load<Texture2D>("shuttle");
            _earth = Content.Load<Texture2D>("earth");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, new Rectangle(0,0,800,480), Color.White);
            _spriteBatch.Draw(_earth, new Vector2(400, 240), Color.White);
            _spriteBatch.Draw(_shuttle, new Vector2(450, 240), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
