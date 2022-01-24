﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public static class Time
    {
        public static event Action OnGameTick = delegate { };

        public const int MinFrameTime = 500;

        public static void Start()
        {
            DateTime startTime;
            while (true)
            {
                startTime = DateTime.Now;
                OnGameTick();
                Thread.Sleep(MinFrameTime - (DateTime.Now - startTime).Milliseconds);
            }
        }
    }
}