using NulleanAndRain.ConsoleGame.Core;
using NulleanAndRain.ConsoleGame.GameClasses.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.GameClasses.MovableObjects
{
    public class Jakal : Enemy
    {
        public const int MaxHP = 20;
        public const int ContactDamage = 10;

        /// <summary>
        /// variable that specifies position of Jacal in 3x3 Square
        /// 
        ///  7 0 1
        ///  6 - 2
        ///  5 4 3
        /// </summary>
        private int _posState = 0;
        private int PosState
        {
            get => _posState;
            set
            {
                _posState = value;
                _posState %= 8;
            }
        }
        private const int FRAMES_FOR_UPDATE = 4;
        private int _frames = 0;

        public Jakal(Point position) : base(MaxHP, position)
        {
            _icon = '@';
            void destroy()
            {
                collider.OnCollision -= Attack;
                OnDestroy -= destroy;
            }
            OnDestroy += destroy;
            collider.OnCollision += Attack;
        }

        public Jakal() : this(Point.Zero) { }

        public override void Update()
        {
            _frames++;
            _frames %= FRAMES_FOR_UPDATE;
            if (_frames != 0) return;

            Point posTo = Position;
            switch (PosState)
            {
                case 0:
                case 7:
                    {
                        posTo = Position + Vector.Right;
                        break;
                    }
                case 1:
                case 2:
                    {
                        posTo = Position + Vector.Down;
                        break;
                    }
                case 3:
                case 4:
                    {
                        posTo = Position + Vector.Left;
                        break;
                    }
                case 5:
                case 6:
                    {
                        posTo = Position + Vector.Up;
                        break;
                    }
                default: break;
            }
            if (Game.CanMoveTo(this, posTo))
            {
                PosState++;
                Game.Move(this, posTo);
            }
        }

        public void Attack(GameObject obj)
        {
            if (Player.IsPlayer(obj))
            {
                var playerHealth = obj.GetComponent<Health>();
                if (playerHealth == null) return;
                playerHealth.HP -= ContactDamage;

                Point posTo = Position;
                switch (PosState)
                {
                    case 0:
                    case 1:
                        {
                            posTo = Position + Vector.Left;
                            break;
                        }
                    case 2:
                    case 3:
                        {
                            posTo = Position + Vector.Up;
                            break;
                        }
                    case 4:
                    case 5:
                        {
                            posTo = Position + Vector.Right;
                            break;
                        }
                    case 6:
                    case 7:
                        {
                            posTo = Position + Vector.Down;
                            break;
                        }
                    default: break;
                }
                Game.Move(this, posTo);
                PosState--;
            }
        }
    }
}
