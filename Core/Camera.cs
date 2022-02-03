using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public class Camera
    {
        public int Width => Console.WindowWidth;
        public int Height => Console.WindowHeight;

        public Point Center { get; set; }

        private GameObject? _moveAfter;

        public Camera(Point center)
        {
            Center = center;
        }

        public Camera(GameObject obj)
        {
            Center = obj.Position;
            _moveAfter = obj;
        }

        public Camera(): this(Point.Zero) {}

        public void CameraTick()
        {
            if (_moveAfter != null)
                Center = _moveAfter.Position;
        }

        public void RenderToConsole(List<string> lines)
        {
            foreach(var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
