using Microsoft.Xna.Framework.Input;
using System;

namespace Mastery.Engine.Input
{
    public class InputManager
    {
        private readonly BaseInputMapper _inputMapper;

        public InputManager(BaseInputMapper inputMapper)
        {
            _inputMapper = inputMapper;
        }

        public void GetCommands(Action<BaseInputCommand> processCommand)
        {
            var keyboardState = Keyboard.GetState();
            foreach (var command in _inputMapper.GetKeyboardCommands(keyboardState))
            {
                processCommand(command);
            }

            var mouseState = Mouse.GetState();
            foreach (var command in _inputMapper.GetMouseCommands(mouseState))
            {
                processCommand(command);
            }

            var gamePadState = GamePad.GetState(0);
            foreach (var command in _inputMapper.GetGamepadState(gamePadState))
            {
                processCommand(command);
            }
        }
    }
}
