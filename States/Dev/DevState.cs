using Mastery.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastery.States.Dev
{
    public class DevState : BaseGameState
    {
        private const string ExhaustTexture = "Cloud";
        private const string MissileTexture = "Missile";
        private const string PlayerFighter = "fighter";

        private ExhaustEmitter _exhaustEmitter;
        private MissileSprite _missile;
        private PlayerSprite _player;

        public override void LoadContent()
        {
            var exhaustPosition = new Vector2(_viewportWidth / 2, _viewportHeight / 2);
        }
    }
}
