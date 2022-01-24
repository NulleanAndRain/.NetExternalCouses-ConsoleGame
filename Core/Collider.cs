using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public class Collider : Component
    {
        public bool IsTigger { get; private set; }

        public Collider(GameObject obj, bool isTigger = false): base(obj)
        {
            IsTigger = isTigger;
        }

        public override void Update() { }

        public event Action<GameObject> OnCollision = delegate { };

        public void CollideWith(GameObject obj)
        {
            OnCollision(obj);
        }
    }
}
