using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NulleanAndRain.ConsoleGame.GameClasses;
using NulleanAndRain.ConsoleGame.Core;
using NulleanAndRain.ConsoleGame.GameClasses.Components;

namespace NulleanAndRain.ConsoleGame.GameClasses.MovableObjects
{
    public abstract class Enemy : GameObject
    {
        protected Health health;
        protected Collider collider;

        protected Enemy(int MaxHP, Point position) : base(position)
        {
            health = new(this, MaxHP);
            collider = new(this);
        }

        protected Enemy(int MaxHP) : this(MaxHP, Point.Zero) { }
    }
}
