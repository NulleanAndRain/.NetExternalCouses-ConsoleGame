using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public class Scene
    {
        private List<GameObject> _sceneObjects = new List<GameObject>();
        public IEnumerable<GameObject> SceneObjects => _sceneObjects;

        public Camera Camera { get; private set; }

        public Scene(Camera camera)
        {
            Camera = camera;
        }

        private List<string> Render(int width, int height, Point center)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            foreach (var obj in SceneObjects)
            {
                obj.Update();
                Camera.RenderToConsole(Render(Camera.Width, Camera.Height, Camera.Center));
            }
        }

        public void AddGameObject(GameObject gameObject)
        {
            _sceneObjects.Add(gameObject);
            void destroy()
            {
                _sceneObjects.Remove(gameObject);
                gameObject.OnDestroy -= destroy;
            }
            gameObject.OnDestroy += destroy;
        }


    }
}
