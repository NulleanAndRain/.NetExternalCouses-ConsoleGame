using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NulleanAndRain.ConsoleGame.Core;

namespace NulleanAndRain.ConsoleGame.GameClasses.StaticSceneObjects
{
    public abstract class Bonus : GameObject
    {
        protected Collider collider;

        public Bonus(Point pos) : base(pos)
        {
            collider = new(this, true);
            collider.OnCollision += OnTrigger;

            void destroy()
            {
                collider.OnCollision -= OnTrigger;
                OnDestroy -= destroy;
            }
            OnDestroy += destroy;
        }

        abstract protected void OnTrigger(GameObject obj);
    }
}
