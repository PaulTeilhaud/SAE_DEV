using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Content;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace SAE_DEV
{
    public class Game1 : Game
    {
        private readonly ScreenManager _screenManager;
        public SpriteBatch SpriteBatch { get; set; }
        Acceuil _acceuil;
        Jeu _jeu;
        Fin _fin;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        


        public Game1()
        {
            
            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }

        protected override void Initialize()
        {
            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _acceuil = new Acceuil(this); // en leur donnant une référence au Game
            _jeu = new Jeu(this);
            _fin = new Fin(this);
            _spriteBatch.Draw(ButtonTexture, ButtonRectangle, Color.White);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            KeyboardState keyboardState = Keyboard.GetState();
            ButtonRectangle = new Rectangle(ScreenX * 0.4, ScreenY * 0.5, ScreenX * 0.1, ScreenY * 0.1);
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _screenManager.LoadScreen(_acceuil, new FadeTransition(GraphicsDevice,
                Color.Black));
            }
            MouseState mouse = Mouse.GetState();
            if (ButtonRectangle.Contains(mouse.Position) && mouse.LeftButton == ButtonState.Pressed)
            {
                //do stuff

                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    _screenManager.LoadScreen(_jeu, new FadeTransition(GraphicsDevice, Color.Black));
                }
                else if (keyboardState.IsKeyDown(Keys.Right))
                {
                    _screenManager.LoadScreen(_fin, new FadeTransition(GraphicsDevice,
                    Color.Black));
                }
            }

           
            base.Update(gameTime);
        }
    

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            
            base.Draw(gameTime);
        }
    }
}