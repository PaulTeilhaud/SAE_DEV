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

namespace SAE_DEV
{

        public class Jeu : Game
        {
            private Game1 _myGame;
        // pour récupérer une référence à l’objet game pour avoir accès à tout ce qui est
        // défini dans Game1
        public Jeu(Game1 game) : base(game)
        {
            _myGame = game;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private Vector2 _positionPerso;
        private AnimatedSprite _perso;
        private KeyboardState _keyboardState;
        private int _sensPerso;
        private int _vitessePerso;
        public const int TAILLE_FENETRE = 640;
                  

        protected override void Initialize()
        {
            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            _positionPerso = new Vector2(20, 340);
            _graphics.PreferredBackBufferHeight = TAILLE_FENETRE;
            _graphics.ApplyChanges();
            _vitessePerso = 600;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tiledMap = Content.Load<TiledMap>("mapGenerale");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            SpriteSheet spriteSheet = Content.Load<SpriteSheet>("persoAnimation.sf", new JsonContentLoader());
            _perso = new AnimatedSprite(spriteSheet);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            
            float deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _tiledMapRenderer.Update(gameTime);
            _perso.Play("idle"); // une des animations définies dans « persoAnimation.sf »
            _perso.Update(deltaSeconds); // time écoulé 
            _keyboardState = Keyboard.GetState();
            if (_keyboardState.IsKeyDown(Keys.Right) && !(_keyboardState.IsKeyDown(Keys.Left)))
            {
                _sensPerso = 1;
                _positionPerso.X += _sensPerso * _vitessePerso * deltaSeconds;
            }
            // si fleche gauche
            else if (_keyboardState.IsKeyDown(Keys.Left) && !(_keyboardState.IsKeyDown(Keys.Right)))
            {
                _sensPerso = 1;
                _positionPerso.X -= _sensPerso * _vitessePerso * deltaSeconds;
            }
            if (_keyboardState.IsKeyDown(Keys.Down) && !(_keyboardState.IsKeyDown(Keys.Up)))
            {
                _sensPerso = 1;
                _positionPerso.Y += _sensPerso * _vitessePerso * deltaSeconds;
            }
            else if (_keyboardState.IsKeyDown(Keys.Up) && !(_keyboardState.IsKeyDown(Keys.Down)))
            {
                _sensPerso = 1;
                _positionPerso.Y -= _sensPerso * _vitessePerso * deltaSeconds;
            }
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _tiledMapRenderer.Draw();
            _spriteBatch.Begin();
            _spriteBatch.Draw(_perso, _positionPerso);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
