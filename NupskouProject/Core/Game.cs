using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace NupskouProject {

    public class Game : Microsoft.Xna.Framework.Game {

        private GraphicsDeviceManager _gfxDevice;
        private SpriteBatch           _spriteBatch;


        public Game () {
            _gfxDevice = new GraphicsDeviceManager (this) {
                PreferredBackBufferWidth  = 800,
                PreferredBackBufferHeight = 600,
                PreferMultiSampling       = true,
                GraphicsProfile           = GraphicsProfile.Reach,
//                IsFullScreen              = true
            };
        }


        protected override void Initialize () {
            base.Initialize ();
            _.World.Update ();
        }


        protected override void LoadContent () {
            // load images
            // load sounds
            _.Assets.Load (Content);
            _spriteBatch = new SpriteBatch (GraphicsDevice);
        }


        protected override void UnloadContent () {
            // unload sounds
            // images managed by content manager
            _.Assets.Unload ();
        }


        protected override void Update (GameTime gameTime) {
            _.Time++;
            _.World.Update ();
            base.Update (gameTime);
        }


        protected override void Draw (GameTime gameTime) {
            GraphicsDevice.Clear (new Color(8, 16, 24));
            _.Renderer.Begin ();
            _.World.Render ();
            _.Renderer.End (_spriteBatch);
        }

    }


}