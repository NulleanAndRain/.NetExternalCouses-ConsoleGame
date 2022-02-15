using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NulleanAndRain.ConsoleGame.Core;

namespace NulleanAndRain.ConsoleGame.GameClasses
{
    public class PlayerProjectile: GameObject
    {
        private Vector _velocity;

        public PlayerProjectile(GameObject owner, Point pos, Vector velocity) : base(pos)
        {
            _icon = '*';
            _velocity = velocity;
            var trigger = new Collider(this);

            void onTriggerEnter(GameObject obj)
            {
                if (obj == owner) return;
                // TODO: Add collision logic

                trigger.OnCollision -= onTriggerEnter;
                Destroy();
            }
            trigger.OnCollision += onTriggerEnter;
        }

        public override void Update()
        {
            Game.Move(this, Position + _velocity);
        }
    }
}
