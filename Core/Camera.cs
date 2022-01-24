﻿using System;
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

        public Camera(Point center)
        {
            Center = center;
        }

        public Camera(): this(Point.Zero) {}

        public void RenderToConsole(List<string> lines)
        {
            foreach(var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
