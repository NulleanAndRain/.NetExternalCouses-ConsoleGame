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

        public GameObject? MoveAfter;

        public event Action OnHUDRender = delegate { };

        public Camera(Point center)
        {
            Center = center;
        }

        public Camera(GameObject obj)
        {
            Center = obj.Position;
            MoveAfter = obj;
        }

        public Camera(): this(Point.Zero) {}

        public void CameraTick()
        {
            if (MoveAfter != null)
                Center = MoveAfter.Position;
        }

        public void RenderToConsole(List<string> lines)
        {
            Console.CursorVisible = false;
            foreach(var line in lines.Take(Height))
            {
                Console.WriteLine(line);
            }
            //OnHUDRender();
            Console.SetCursorPosition(0, 0);
        }
    }
}
