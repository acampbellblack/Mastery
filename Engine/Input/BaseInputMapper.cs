using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Mastery.Engine.Input
{
    public class BaseInputMapper
    {
        public virtual IEnumerable<BaseInputCommand> GetKeyboardCommands(KeyboardState state)
        {
            return new List<BaseInputCommand>();
        }

        public virtual IEnumerable<BaseInputCommand> GetMouseCommands(MouseState state)
        {
            return new List<BaseInputCommand>();
        }

        public virtual IEnumerable<BaseInputCommand> GetGamePadCommands(GamePadState state)
        {
            return new List<BaseInputCommand>();
        }
    }
}
