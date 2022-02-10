using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NulleanAndRain.ConsoleGame.Core;

namespace NulleanAndRain.ConsoleGame.Game.Components
{
    public class Health : Component
    {
        private int _hp;
        private int _maxHp;

        public event Action OnDeath = delegate { };
        public bool IsDead { get; private set; }

        public int HP
        {
            get => _hp;
            set
            {
                _hp = value;
                if (_hp < 0)
                {
                    OnDeath();
                    IsDead = true;
                    _hp = 0;
                    return;
                }
                IsDead = false;
                if (_hp > MaxHP) _hp = MaxHP;
            }
        }

        public int MaxHP
        {
            get => _maxHp;
            set
            {
                if (value < 1) _maxHp = 1;
                else _maxHp = value;
            }
        }

        public Health(GameObject gameObject, int maxHP) : base(gameObject)
        {
            MaxHP = maxHP;
            HP = maxHP;
        }
    }
}
