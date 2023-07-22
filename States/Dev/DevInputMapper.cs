using Mastery.Engine.Input;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Mastery.States.Dev
{
    public class DevInputMapper : BaseInputMapper
    {
        public override IEnumerable<BaseInputCommand> GetKeyboadState(KeyboardState state)
        {
            var commands = new List<BaseInputCommand>();

            if (state.IsKeyDown(Keys.Escape))
            {
                commands.Add(new DevInputCommand.DevQuit());
            }

            if (state.IsKeyDown(Keys.Space))
            {
                commands.Add(new DevInputCommand.DevShoot());
            }

            return commands;
        }
    }
}
