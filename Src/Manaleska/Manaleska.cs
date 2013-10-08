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
        private AnimatedSprite animatedSprite;
        
        //Menu
        enum GameState
        {
            MainMenu,
            Options,
            Playing,
        }
        GameState CurrentGameState = GameState.MainMenu;

        // Screen Adjusments
        int screenWidth = 800, screenHeight = 600;

        Button btnPlay;
        //FIN Menu

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
            // TODO: use this.Content to load your game content here

            //Menu
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            btnPlay = new Button(Content.Load<Texture2D>("button"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(350, 300));

            //Smiley qui danse
            //Texture2D texture = Content.Load<Texture2D>("SmileyWalk");
            //animatedSprite = new AnimatedSprite(texture, 4, 4);
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
            MouseState mouse = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.isClicked == true) CurrentGameState = GameState.Playing;
                    btnPlay.Update(mouse);
                    break;

                case GameState.Options:
                    break;

                case GameState.Playing:
                    break;
            }

            //animatedSprite.Update();

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

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    _spriteBatch.Draw(Content.Load<Texture2D>("MainMenu"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    btnPlay.Draw(_spriteBatch);
                    break;

                case GameState.Options:
                    break;

                case GameState.Playing:
                    break;
            }
            

            //animatedSprite.Draw(_spriteBatch, new Vector2(400, 200));
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
