using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NulleanAndRain.ConsoleGame.Core;

namespace NulleanAndRain.ConsoleGame.GameClasses
{
    public class Obstacle : GameObject
    {
        private Collider _collider;

        public Obstacle(Point pos) : base(pos)
        {
            _icon = '#';
            _collider = new Collider(this);

            void onCollision(GameObject _)
            {
                _icon = '|';
            }
            _collider.OnCollision += onCollision;
        }

        public Obstacle() : this(Point.Zero) { }
    }
}
