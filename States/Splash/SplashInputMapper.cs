using Mastery.Engine.Input;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Mastery.States.Splash
{
    public class SplashInputMapper : BaseInputMapper
    {
        public override IEnumerable<BaseInputCommand> GetKeyboardCommands(KeyboardState state)
        {
            var commands = new List<SplashInputCommand>();

            if (state.IsKeyDown(Keys.Enter))
            {
                commands.Add(new SplashInputCommand.GameSelect());
            }

            return commands;
        }

    }
}
