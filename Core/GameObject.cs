using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public abstract class GameObject
    {
        public Point Position { get; protected set; }

        public virtual char Icon { get; } = ' ';

        private List<Component> _components = new();

        public event Action OnDestroy = delegate { };

        public GameObject() : this(Point.Zero) { }

        public GameObject(Point position)
        {
            Position = position;
            Time.OnGameTick += UpdateComponents;
        }

        private void UpdateComponents()
        {
            foreach (var component in _components)
            {
                component.Update();
            }
        }

        public void Destroy()
        {
            OnDestroy();
            Time.OnGameTick -= UpdateComponents;
        }

        public virtual void Update() { }

        protected void AddComponent(Component component) => _components.Add(component);

        public T? GetComponent<T>() where T: Component => _components.OfType<T>().FirstOrDefault();
    }
}
