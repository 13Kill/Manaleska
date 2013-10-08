#region Using Statements
using System;
using System.Runtime.InteropServices;
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
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint MessageBox(IntPtr hWnd, String text, String caption, uint type); // Pour pouvoir utiliser les MessageBox

        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;
        Texture2D btnNewGame, btnOptions, btnExit;
        Vector2 btnNewGamePosition = new Vector2((GraphicsDeviceManager.DefaultBackBufferWidth/2)-75, 70); // tout ça pour centrer le bouton, bidouille impacto
        Vector2 btnOptionsPosition = new Vector2((GraphicsDeviceManager.DefaultBackBufferWidth / 2) - 75, 130);
        Vector2 btnExitPosition = new Vector2((GraphicsDeviceManager.DefaultBackBufferWidth / 2) - 75, 190);
        Rectangle btnNewGameArea = new Rectangle((GraphicsDeviceManager.DefaultBackBufferWidth / 2) - 75, 70, 150, 50); // La surface où se situe le bouton "Nouvelle Partie"
        Rectangle btnOptionsArea = new Rectangle((GraphicsDeviceManager.DefaultBackBufferWidth / 2) - 75, 130, 150, 50);
        Rectangle btnExitArea = new Rectangle((GraphicsDeviceManager.DefaultBackBufferWidth / 2) - 75, 190, 150, 50);
        bool overNewGame = false;
        bool overOptions = false;
        bool overExit = false;


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
            this.btnNewGame = Content.Load<Texture2D>("newGame");
            this.btnOptions = Content.Load<Texture2D>("options");
            this.btnExit = Content.Load<Texture2D>("exit");
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
            MouseState mouse = Mouse.GetState();
            Point mousePosition = new Point(mouse.X, mouse.Y);
            if (btnNewGameArea.Contains(mousePosition)) overNewGame = true;
                else overNewGame = false;
            if (btnOptionsArea.Contains(mousePosition)) overOptions = true;
                else overOptions = false;
            if (btnExitArea.Contains(mousePosition)) overExit = true;
                else overExit = false;
   
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
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

            if (!overNewGame) _spriteBatch.Draw(this.btnNewGame, this.btnNewGamePosition, Color.White);
                else _spriteBatch.Draw(Content.Load<Texture2D>("overNewGame"), this.btnNewGamePosition, Color.White);

            if(!overOptions) _spriteBatch.Draw(this.btnOptions, this.btnOptionsPosition, Color.White);
                else _spriteBatch.Draw(Content.Load<Texture2D>("overOptions"), this.btnOptionsPosition, Color.White);  
                   
            if (!overExit)_spriteBatch.Draw(this.btnExit, this.btnExitPosition, Color.White);
                else _spriteBatch.Draw(Content.Load<Texture2D>("overExit"), this.btnExitPosition, Color.White);   

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
