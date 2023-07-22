using Mastery.Engine.Input;

namespace Mastery.States.Dev
{
    public class DevInputCommand : BaseInputCommand
    {
        public class DevQuit : DevInputCommand { }
        public class DevShoot : DevInputCommand { }
    }
}
