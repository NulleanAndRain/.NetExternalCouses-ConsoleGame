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
        public Obstacle(Point pos) : base(pos)
        {
            _icon = '#';
            var collider = new Collider(this);
        }

        public Obstacle() : this(Point.Zero) { }
    }
}
