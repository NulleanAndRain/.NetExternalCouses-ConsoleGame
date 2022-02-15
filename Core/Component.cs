using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public abstract class Component
    {
        public virtual void Update() { }

        public readonly GameObject gameObject;

        protected Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
            gameObject.AddComponent(this);
        }

        public T? GetComponent<T>() where T : Component => gameObject.GetComponent<T>();
    }
}
