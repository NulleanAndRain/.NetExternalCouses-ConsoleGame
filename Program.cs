using System;
using System.Collections.Generic;
using System.Linq;
using NulleanAndRain.ConsoleGame.Core;
using NulleanAndRain.ConsoleGame.GameClasses;

namespace NulleanAndRain.ConsoleGame
{
    public class Program
    {
        private const string _filePath = @"./Map1.txt";
        public static void Main(string[] args)
        {
            var scene = SceneBuilder.ReadSceneFromFile(_filePath);
            var game = new Game(scene);
            game.Start();
        }
    }
}