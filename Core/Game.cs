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

        public Game()
        {
            var camera = new Camera();
            _scene = new Scene(camera);
            Time.OnGameTick += _scene.Update;
        }

        public void Start() => Time.Start();
    }
}
