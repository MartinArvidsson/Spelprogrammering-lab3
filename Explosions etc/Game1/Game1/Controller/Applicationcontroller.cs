using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using View;
using Model;
namespace Controller
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Applicationcontroller : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Camera camera = new Camera();
        BallSimulation ballsim;
        private Startview startview;
        MouseState lastmouseclick;

        public Applicationcontroller()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 600;
            graphics.IsFullScreen = false;
            IsMouseVisible = true;
            graphics.ApplyChanges();
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            camera.SetFieldSize(graphics.GraphicsDevice.Viewport);
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ballsim = new BallSimulation();
            //explosionview = new Applicationview(Content, camera, spriteBatch);
            startview = new Startview(Content, camera, spriteBatch,ballsim,graphics);
            
            
            // TODO: use this.Content to load your game content here
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            var currentmouse = Mouse.GetState();
            if (lastmouseclick.LeftButton == ButtonState.Released && currentmouse.LeftButton == ButtonState.Pressed)
            {
                startview.CreateExplosion(currentmouse.X, currentmouse.Y, spriteBatch);
                //explosionview = new Explosionview(Content, camera, spriteBatch);
            }
            lastmouseclick = currentmouse;
            // TODO: Add your update logic here
            //if(explosionview != null)
            //{
            //    explosionview.UpdateGame((float)gameTime.ElapsedGameTime.TotalSeconds);
            //}
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            startview.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Draw(gameTime);
        }
    }
}
