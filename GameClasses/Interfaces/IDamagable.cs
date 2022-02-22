using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NulleanAndRain.ConsoleGame.GameClasses.Components;

namespace NulleanAndRain.ConsoleGame.GameClasses.Interfaces
{
    public interface IDamagable
    {
        public Health Health { get; }
    }
}
