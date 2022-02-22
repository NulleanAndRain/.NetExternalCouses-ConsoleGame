using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NulleanAndRain.ConsoleGame.Core;
using NulleanAndRain.ConsoleGame.GameClasses;
using NulleanAndRain.ConsoleGame.GameClasses.Components;

namespace NulleanAndRain.ConsoleGame.GameClasses.StaticSceneObjects
{
    public class HealthBonus : Bonus
    {
        public const int HealthRestored = 10;

        public HealthBonus(Point pos) : base(pos)
        {
            _icon = '+';
        }

        public HealthBonus() : this(Point.Zero) { }

        protected override void OnTrigger(GameObject obj)
        {
            if (Player.IsPlayer(obj))
            {
                var playerHealth = obj.GetComponent<Health>();
                if (playerHealth == null) return;
                playerHealth.HP += HealthRestored;
                Destroy();
            }
        }
    }
}
