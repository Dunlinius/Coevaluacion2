using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Desierto
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle rect;
        Rectangle rgb;
        Rectangle rgb1;
        Rectangle rgb2;
        Rectangle rgb3;
        Texture2D[] frames;
        Texture2D tbg;
        Texture2D tbg1;
        Texture2D tbg2;
        Texture2D tbg3;
        int i = 0;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 900;
            _graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            rect = new Rectangle(0,410,326,190);
            rgb = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            rgb1 = new Rectangle(_graphics.PreferredBackBufferWidth, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            rgb2 = new Rectangle(_graphics.PreferredBackBufferWidth*2, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            rgb3 = new Rectangle(_graphics.PreferredBackBufferWidth*3, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            frames = new Texture2D[3];
            frames[0] = Content.Load<Texture2D>("Car3");
            frames[1] = Content.Load<Texture2D>("Car2");
            frames[2] = Content.Load<Texture2D>("Car1");
            //frames[3] = Content.Load<Texture2D>("Car4");
            tbg = Content.Load<Texture2D>("fondo");
            tbg1 = Content.Load<Texture2D>("Fondo1");
            tbg2 = Content.Load<Texture2D>("Fondo2");
            tbg3 = Content.Load<Texture2D>("fondo3");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState kbs = Keyboard.GetState();
            if (kbs.IsKeyDown(Keys.Left)) rect.X -= 4;
            if (kbs.IsKeyDown(Keys.Right)) rect.X += 4;
            rgb.X -= 10;
            rgb1.X -= 10;
            rgb2.X -= 10;
            rgb3.X -= 10;

            if (rgb.X == -_graphics.PreferredBackBufferWidth)
                rgb.X = _graphics.PreferredBackBufferWidth*3;
            if (rgb1.X == -_graphics.PreferredBackBufferWidth)
                rgb1.X = _graphics.PreferredBackBufferWidth*3;
            if (rgb2.X == -_graphics.PreferredBackBufferWidth)
                rgb2.X = _graphics.PreferredBackBufferWidth*3;
            if (rgb3.X == -_graphics.PreferredBackBufferWidth)
                rgb3.X = _graphics.PreferredBackBufferWidth*3;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(tbg, rgb, Color.White);
            _spriteBatch.Draw(tbg1, rgb1, Color.White);
            _spriteBatch.Draw(tbg2, rgb2, Color.White);
            _spriteBatch.Draw(tbg3, rgb3, Color.White);
            _spriteBatch.Draw(frames[i], rect, Color.White);
            _spriteBatch.End();


            //quiero bajar los frames con
            //if(gameTime.TotalGameTime.Milliseconds%7==0)
            i++;
            if (i > 2) i = 0;

            
            base.Draw(gameTime);
        }
    }
}