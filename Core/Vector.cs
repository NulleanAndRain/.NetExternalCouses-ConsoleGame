using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public struct Vector
    {
        public int X, Y;

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Magnitude => Math.Sqrt(Math.Abs(X * X + Y * Y));

        public static Vector Zero => new Vector(0, 0);

        public static bool operator ==(Vector vec1, Vector vec2) => 
            vec1.X == vec2.X && vec1.Y == vec2.Y;

        public static bool operator !=(Vector vec1, Vector vec2) => !(vec1 == vec2);
    }
}
