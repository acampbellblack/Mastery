using Mastery.Engine.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mastery.Engine
{
    public class MainGame : Game
    {
        private BaseGameState _currentGameState;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private RenderTarget2D _renderTarget;
        private Rectangle _renderScaleRectangle;

        private int _designedResolutionWidth;
        private int _designedResolutionHeight;
        private float _designedResolutionAspectRatio;

        private BaseGameState _firstGameState;

        public MainGame(int width, int height, BaseGameState firstGameState)
        {
            Content.RootDirectory = "Content";
            _graphics = new GraphicsDeviceManager(this);

            _firstGameState = firstGameState;
            _designedResolutionWidth = width;
            _designedResolutionHeight = height;
            _designedResolutionAspectRatio = (float)width / height;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = _designedResolutionWidth;
            _graphics.PreferredBackBufferHeight = _designedResolutionHeight;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            _renderTarget = new RenderTarget2D(_graphics.GraphicsDevice, _designedResolutionWidth, _designedResolutionHeight);

            _renderScaleRectangle = GetScaleRectangle();

            base.Initialize();
        }

        private Rectangle GetScaleRectangle()
        {
            var variance = 0.5;
            var actualAspectRatio = (float)Window.ClientBounds.Width / Window.ClientBounds.Height;

            Rectangle scaleRectangle;
            
            if (actualAspectRatio <= _designedResolutionAspectRatio)
            {
                var presentHeight = (int)(Window.ClientBounds.Width / _designedResolutionAspectRatio + variance);
                var barHeight = (Window.ClientBounds.Height - presentHeight) / 2;

                scaleRectangle = new Rectangle(0, barHeight, Window.ClientBounds.Width, presentHeight);
            }
            else
            {
                var presentWidth = (int)(Window.ClientBounds.Height * _designedResolutionAspectRatio + variance);
                var barWidth = (Window.ClientBounds.Width - presentWidth) / 2;

                scaleRectangle = new Rectangle(barWidth, 0, presentWidth, Window.ClientBounds.Height);
            }

            return scaleRectangle;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            SwitchGameState(_firstGameState);
        }

        private void _currentGameState_OnStateSwitched(object sender, BaseGameState gameState)
        {
            SwitchGameState(gameState);
        }

        private void SwitchGameState(BaseGameState gameState)
        {
            if (_currentGameState != null)
            {
                _currentGameState.OnStateSwitched -= _currentGameState_OnStateSwitched;
                _currentGameState.OnEventNotification -= _currentGameState_OnEventNotification;
                _currentGameState.UnloadContent();
            }

            _currentGameState = gameState;
            _currentGameState.Initialize(Content, _graphics.GraphicsDevice.Viewport.Width, _graphics.GraphicsDevice.Viewport.Height);
            _currentGameState.LoadContent();

            _currentGameState.OnStateSwitched += _currentGameState_OnStateSwitched;
            _currentGameState.OnEventNotification += _currentGameState_OnEventNotification;
        }

        private void _currentGameState_OnEventNotification(object sender, BaseGameStateEvent gameEvent)
        {
            switch (gameEvent)
            {
                case BaseGameStateEvent.GameQuit _:
                    Exit();
                    break;
            }
        }

        protected override void UnloadContent()
        {
            _currentGameState?.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _currentGameState.HandleInput(gameTime);
            _currentGameState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(_renderTarget);
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();
            
            _currentGameState.Render(_spriteBatch);
           
            _spriteBatch.End();

            _graphics.GraphicsDevice.SetRenderTarget(null);

            
            _graphics.GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            
            _spriteBatch.Draw(_renderTarget, _renderScaleRectangle, Color.White);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}