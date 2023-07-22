using Mastery.Engine.Input;
using Mastery.Engine.Objects;
using Mastery.Engine.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastery.Engine.States
{
    public abstract class BaseGameStateEvent
    {
        private const string FallbackTexture = "Empty";
        private const string FallbackSong = "EmptySound";

        private ContentManager _contentManager;
        protected int _viewportWidth;
        protected int _viewportHeight;
        protected SoundManager _soundManager = new SoundManager();

        private readonly List<BaseGameObject> _gameObjects = new List<BaseGameObject>();

        protected InputManager InputManager { get; set; }

        public void Initialize(ContentManager contentManager, int viewportWidth, int viewportHeight)
        {
            _contentManager = contentManager;
            _viewportWidth = viewportWidth;
            _viewportHeight = viewportHeight;

            SetInputManager();
        }

        public abstract void LoadContent();
        public abstract void HandleInput(GameTime gameTime);
        public abstract void UpdateGameState(GameTime gameTime);

        public event EventHandler<BaseGameStateEvent> OnStateSwitched;
        public event EventHandler<BaseGameStateEvents> OnEventNotification;
        protected abstract void SetInputManager();

        public void UnloadContent()
        {
            _contentManager.Unload();
        }

        public void Update(GameTime gameTime)
        {
            UpdateGameState(gameTime);
            _soundManager.PlaySoundtrack();
        }

        protected Texture2D LoadTexture(string textureName)
        {
            return _contentManager.Load<Texture2D>(textureName);
        }

        protected SoundEffect LoadSound(string soundName)
        {
            return _contentManager.Load<SoundEffect>(soundName);
        }

        protected void NotifyEvent(BaseGameStateEvents gameEvent)
        {
            OnEventNotification?.Invoke(this, gameEvent);

            foreach (var gameObject in _gameObjects)
            {
                gameObject.OnNotify(gameEvent);
            }

            _soundManager.OnNotify(gameEvent);
        }

        protected void SwitchState(BaseGameStateEvent state)
        {
            OnStateSwitched?.Invoke(this, state);
        }

        protected void AddGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        protected void RemoveGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
        }

        public void Render(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in _gameObjects.OrderBy(a => a.zIndex))
            {
                gameObject.Render(spriteBatch);
            }
        }
    }
}
