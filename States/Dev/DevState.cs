using Mastery.Engine.Input;
using Mastery.Engine.States;
using Mastery.Objects;
using Microsoft.Xna.Framework;

namespace Mastery.States.Dev
{
    public class DevState : BaseGameState
    {
        private const string CloudTexture = "explosion";
        private const string ChopperTexture = "Chopper";

        private ChopperSprite _chopper;

        public override void LoadContent()
        {
            _chopper = new ChopperSprite(LoadTexture(ChopperTexture), new System.Collections.Generic.List<(int, Vector2)>
            {
                (0, new Vector2(1.0f, 0.0f)),
                (120, new Vector2(0.0f, 1.0f)),
            });
            _chopper.Position = new Vector2(300, 100);
            AddGameObject(_chopper);
        }

        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                if (cmd is DevInputCommand.DevQuit)
                {
                    NotifyEvent(new BaseGameStateEvent.GameQuit());
                }
            });
        }

        public override void UpdateGameState(GameTime gameTime)
        {
            _chopper.Update();
        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new DevInputMapper());
        }
    }
}
