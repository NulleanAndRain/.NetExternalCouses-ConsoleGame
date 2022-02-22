using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public struct HudData
    {
        public IEnumerable<string>? lines;
        public Point ScreenPos;

        public HudData(IEnumerable<string>? lines, Point screenPos)
        {
            this.lines = lines;
            ScreenPos = screenPos;
        }

        public HudData() : this(null, Point.Zero) { }
    }
}
