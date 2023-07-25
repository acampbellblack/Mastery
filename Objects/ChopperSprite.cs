using Mastery.Engine.Objects;
using Mastery.Engine.States;
using Mastery.States.Gameplay;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mastery.Objects
{
    public class ChopperSprite : BaseGameObject
    {
        private const int ChopperStartX = 0;
        private const int ChopperStartY = 1;
        private const int ChopperWidth = 44;
        private const int ChopperHeight = 98;

        private const int BladesStartX = 133;
        private const int BladesStartY = 98;
        private const int BladesWidth = 94;
        private const int BladesHeight = 94;

        private const float BladesCenterX = 47.5f;
        private const float BladesCenterY = 47.5f;

        private const int ChopperBladesPosX = ChopperWidth / 2;
        private const int ChopperBladesPosY = 34;

        private int _life = 40;

        public ChopperSprite(Texture2D texture)
        {
            _texture = texture;
        }

        public override void OnNotify(BaseGameStateEvent gameEvent)
        {
            switch (gameEvent)
            {
                case GameplayEvents.ChopperHitBy m:
                    JustHit(m.HitBy);
                    SendEvent(new GameplayEvents.EnemyLostLife(_life));
                    break;
            }
        }

        private void JustHit(IGameObjectWithDamage o)
        {
            _hitAt = 0;
            _life -= o.Damage;
        }


    }
}
