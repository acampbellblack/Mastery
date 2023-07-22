using Mastery.Engine.Input;
using Mastery.Engine.States;
using Mastery.Objects;
using Mastery.States.Gameplay;
using Microsoft.Xna.Framework;

namespace Mastery.States.Splash
{
    public class SplashState : BaseGameStateEvent
    {
        public override void LoadContent()
        {
            AddGameObject(new SplashImage(LoadTexture("splash")));
        }

        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                if (cmd is SplashInputCommand.GameSelect)
                {
                    SwitchState(new GameplayState());
                }
            });
        }

        public override void UpdateGameState(GameTime _) { }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new SplashInputMapper());
        }
    }
}
