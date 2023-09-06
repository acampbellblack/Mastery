using Mastery.Engine.Objects;
using Mastery.Engine.States;

namespace Mastery.States.Gameplay
{
    public class GameplayEvent : BaseGameStateEvent
    {
        public class PlayerShootsBullets : GameplayEvent { }
        public class PlayerShootsMissile : GameplayEvent { }

        public class ChopperHitBy : GameplayEvent
        {
            public IGameObjectWithDamage HitBy { get; private set; }
            public ChopperHitBy(IGameObjectWithDamage gameObject)
            {
                HitBy = gameObject;
            }
        }

        public class EnemyLostLife : GameplayEvent
        {
            public int CurrentLife { get; private set; }
            public EnemyLostLife(int currentLife)
            {
                CurrentLife = currentLife;
            }
        }
    }
}
