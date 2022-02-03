using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public class Game
    {
        private Scene _scene;

        private static Game _instance;
        public static Game Instance => _instance ??= new Game();

        public Game() : this(new Scene(new Camera())) { }

        public Game(Scene scene)
        {
            _scene = scene;
            Time.OnGameTick += _scene.Update;
        }

        public void Start() => Time.Start();

        public static bool CanMoveTo(GameObject obj, Point posTo) => Instance._scene.CanMoveTo(obj, posTo);
    }
}
