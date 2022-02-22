using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NulleanAndRain.ConsoleGame.Core;
using NulleanAndRain.ConsoleGame.GameClasses.Interfaces;

namespace NulleanAndRain.ConsoleGame.GameClasses.MovableObjects
{
    public class PlayerProjectile: GameObject
    {
        private Vector _velocity;
        private const int PROJECTILE_DAMAGE = 10;
        private GameObject _owner;
        private Collider _trigger;

        public PlayerProjectile(GameObject owner, Point pos, Vector velocity) : base(pos)
        {
            _icon = '*';
            _velocity = velocity;
            _owner = owner;
            _trigger = new Collider(this);
            _trigger.OnCollision += TriggerEnter;
        }

        private void TriggerEnter(GameObject obj)
        {
            if (obj == _owner) return;
            _trigger.OnCollision -= TriggerEnter;
            Destroy();

            var enemy = obj as IDamagable;
            if (enemy == null) return;

            enemy.Health.HP -= PROJECTILE_DAMAGE;
        }

        public override void Update()
        {
            Game.Move(this, Position + _velocity);
        }
    }
}
