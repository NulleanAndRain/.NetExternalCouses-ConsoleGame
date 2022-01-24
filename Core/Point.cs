
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public struct Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point Zero => new Point(0, 0);
    }
}
