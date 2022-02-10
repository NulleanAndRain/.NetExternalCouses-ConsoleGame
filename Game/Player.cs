using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NulleanAndRain.ConsoleGame.Core;
using NulleanAndRain.ConsoleGame.Game.Components;

namespace NulleanAndRain.ConsoleGame.Game
{
    public class Player : GameObject
    {
        enum Direction
        {
            Up,
            Right,
            Down,
            Left
        }

        private Collider _collider;
        private Health _health;
        private Direction dir;

        public const int DefaultMaxHP = 100;

        public Player(Point pos) : base(pos)
        {
            _collider = new Collider(this, false);
            AddComponent(_collider);

            _health = new Health(this, DefaultMaxHP);
            AddComponent(_health);
        }

        public override char Icon
        {
            get
            {
                switch (dir)
                {
                    case Direction.Up: return '^';
                    case Direction.Right: return '>';
                    case Direction.Down: return 'v';
                    case Direction.Left: return '<';
                }
                return '^';
            }
        }

        public override void Update()
        {
            if (_health.IsDead) return;
            var key = Input.Key;
            if (key != Input.Constants.EmptyKey)
            {
                var vec = Vector.Zero;
                switch (key)
                {
                    case Input.Constants.KeyAttack:
                        {
                            Attack();
                            break;
                        }
                    case Input.Constants.KeyUp:
                        {
                            vec.Y = 1;
                            dir = Direction.Up;
                            break;
                        }
                    case Input.Constants.KeyRight:
                        {
                            vec.X = 1;
                            dir = Direction.Right;
                            break;
                        }
                    case Input.Constants.KeyDown:
                        {
                            vec.Y = -1;
                            dir = Direction.Down;
                            break;
                        }
                    case Input.Constants.KeyLeft:
                        {
                            vec.X = -1;
                            dir = Direction.Left;
                            break;
                        }
                    default: break;
                }
            }
        }

        private static void Attack()
        {

        }
    }
}
