using NulleanAndRain.ConsoleGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.GameClasses.StaticSceneObjects
{
    public class DisappearingBonus : Bonus
    {
        public DisappearingBonus(Point point) : base(point)
        {
            _icon = 'O';
        }

        public DisappearingBonus() : this(Point.Zero) { }

        protected override void OnTrigger(GameObject obj)
        {
            Destroy();
        }
    }
}
