using Mastery.Engine.States;

namespace Mastery.States.Gameplay
{
    public class GameplayEvents : BaseGameStateEvents
    {
        public class PlayerShootsBullets : GameplayEvents { }
        public class PlayerShootsMissile : GameplayEvents { }
    }
}
