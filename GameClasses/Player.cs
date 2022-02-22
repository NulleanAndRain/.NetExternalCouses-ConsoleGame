using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NulleanAndRain.ConsoleGame.Core;
using NulleanAndRain.ConsoleGame.GameClasses.Components;
using NulleanAndRain.ConsoleGame.GameClasses.MovableObjects;

namespace NulleanAndRain.ConsoleGame.GameClasses
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
        private Direction dir = Direction.Up;

        public Point SpawnPoint { get; set; }

        public const int DefaultMaxHP = 100;
        private const double RESPAWN_TIME = 2d;
        private Point RenderPos { get; } = Point.Zero;

        public Player(Point pos) : base(pos)
        {
            _collider = new Collider(this, false);
            _health = new Health(this, DefaultMaxHP);
            SpawnPoint = pos;

            void respawn()
            {
                Time.DoAfterTime(() =>
                {
                    _health.HP = _health.MaxHP;
                    Game.Move(this, SpawnPoint);
                    _health.OnDeath += respawn;
                },
                RESPAWN_TIME);
                _health.OnDeath -= respawn;
            }

            _health.OnDeath += respawn;

            Game.AddToOnHudRenderEvent(RenderHUD);
            void destroy()
            {
                //Game.MainCamera.OnHUDRender -= RenderHUD;
                Game.RemoveFromOnHudRenderEvent(RenderHUD);
                OnDestroy -= destroy;
            }
            OnDestroy += destroy;
        }

        public override char Icon
        {
            get
            {
                if (_health.IsDead) return 'F';
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
                var velocity = Vector.Zero;
                switch (key)
                {
                    case Input.Constants.KeyAttack:
                        {
                            Attack();
                            break;
                        }
                    case Input.Constants.KeyUp:
                        {
                            velocity = Vector.Up;
                            dir = Direction.Up;
                            break;
                        }
                    case Input.Constants.KeyRight:
                        {
                            velocity = Vector.Right;
                            dir = Direction.Right;
                            break;
                        }
                    case Input.Constants.KeyDown:
                        {
                            velocity = Vector.Down;
                            dir = Direction.Down;
                            break;
                        }
                    case Input.Constants.KeyLeft:
                        {
                            velocity = Vector.Left;
                            dir = Direction.Left;
                            break;
                        }
                    default: break;
                }
                if (velocity != Vector.Zero)
                {
                    Game.Move(this, Position + velocity);
                }
            }
        }

        private void Attack()
        {
            Vector vel;
            switch (dir)
            {
                case Direction.Up:
                    vel = Vector.Up;
                    break;
                case Direction.Right:
                    vel = Vector.Right;
                    break;
                case Direction.Left:
                    vel = Vector.Left;
                    break;
                case Direction.Down:
                    vel = Vector.Down;
                    break;
                default:
                    vel = Vector.Up;
                    break;
            }

            Game.AddToScene(new PlayerProjectile(this, Position + vel, vel));
        }


        private HudData RenderHUD()
        {
            var lines = new List<string>(3);
            var status = $"{_health.HP} / {_health.MaxHP}";
            var width = status.Length + 4;
            var hudLine = new string('=', width);

            lines.Add(hudLine);
            lines.Add($"| {status} |");
            lines.Add(hudLine);

            return new HudData(lines, RenderPos);
        }

        public static bool IsPlayer(GameObject obj) => obj.GetType() == typeof(Player);
    }
}
