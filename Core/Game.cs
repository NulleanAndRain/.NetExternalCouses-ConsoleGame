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

        private static Game? _instance;
        public static Game Instance => _instance ??= new Game();

        public static Camera MainCamera => Instance._scene.Camera;

        public Game() : this(new Scene(new Camera())) { }

        public Game(Scene scene)
        {
            _scene = scene;
            Time.OnGameTick += _scene.Update;
            _instance = this;
        }

        public void Start() => Time.Start();

        public static bool CanMoveTo(GameObject obj, Point posTo) => Instance._scene.CanMoveTo(obj, posTo);

        public static void Move(GameObject obj, Point posTo)
        {
            if (CanMoveTo(obj, posTo))
            {
                obj.Position = posTo;
            }
        }

        public static T CreateGameObject<T>(Point pos) where T: GameObject, new()
        {
            var obj = new T();
            obj.Position = pos;
            Instance._scene.AddGameObject(obj);
            return obj;
        }

        public static void AddToScene(GameObject obj)
        {
            Instance._scene.AddGameObject(obj);
        }
    }
}
