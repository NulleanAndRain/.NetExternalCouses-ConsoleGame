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

        private GameObject _lastRenderableObj;
        public GameObject LastRenderableObj
        {
            get => _lastRenderableObj;
            set
            {
                if (_lastRenderableObj != null) return;
                _lastRenderableObj = value;
                _sceneObjects.Add(value);
                void destroy()
                {
                    _sceneObjects.Remove(value);
                    value.OnDestroy -= destroy;
                }
                value.OnDestroy += destroy;
            }
        }

        public Camera Camera { get; private set; }

        public Scene(Camera camera)
        {
            Camera = camera;
        }

        private List<string> GetSceneView()
        {
            var leftBorder = Camera.Center.X - Camera.Width / 2;
            var rightBorder = leftBorder + Camera.Width;
            var topBorder = Camera.Center.Y + Camera.Height / 2;
            var bottomBorder = topBorder - Camera.Height;

            var screen = new char[Camera.Height, Camera.Width];
            for (var i = 0; i < Camera.Height; i++)
            {
                for (var j = 0; j < Camera.Width; j++)
                {
                    screen[i, j] = ' ';
                }
            }

            var objects = _sceneObjects.Where(obj =>
                obj.Position.X >= leftBorder &&
                obj.Position.X <= rightBorder &&
                obj.Position.Y <= topBorder &&
                obj.Position.Y >= bottomBorder
            ).ToArray();

            foreach (var obj in objects)
            {
                screen[obj.Position.Y - bottomBorder, obj.Position.X - leftBorder] = obj.Icon;
            }

            if (LastRenderableObj != null &&
                LastRenderableObj.Position.X >= leftBorder &&
                LastRenderableObj.Position.X <= rightBorder &&
                LastRenderableObj.Position.Y <= topBorder &&
                LastRenderableObj.Position.Y >= bottomBorder)
            {
                var obj = LastRenderableObj;
                screen[obj.Position.Y - bottomBorder, obj.Position.X - leftBorder] = obj.Icon;
            }

            var lines = new List<string>();
            var sb = new StringBuilder();
            for (int i = 0; i < Camera.Height; i++)
            {
                for (int w = 0; w < Camera.Width; w++)
                {
                    sb.Append(screen[i, w]);
                }
                lines.Add(new string(sb.ToString()));
                sb.Clear();
            }

            return lines;
        }

        public void Update()
        {
            foreach (var obj in SceneObjects.ToArray())
            {
                obj.Update();
            }
            Camera.CameraTick();
            Camera.RenderToConsole(GetSceneView());
        }

        public bool CanMoveTo(GameObject movingObject, Point posTo)
        {
            return !_sceneObjects.Where(obj => obj != movingObject)
                .Where(obj => obj.Position.X == posTo.X && obj.Position.Y == posTo.Y)
                .Select(obj =>
                {
                    if (obj.TryGetComponent<Collider>(out var collider))
                    {
                        if (movingObject.TryGetComponent<Collider>(out var coll1))
                        {
                            coll1.CollideWith(obj);
                        }
                        collider.CollideWith(movingObject);
                        if (!collider.IsTrigger)
                            return obj;
                    }
                    return null;
                }).Any(obj => obj != null);
        }

        public Scene AddGameObject(GameObject gameObject)
        {
            if (gameObject == LastRenderableObj) return this;
            _sceneObjects.Add(gameObject);
            void destroy()
            {
                _sceneObjects.Remove(gameObject);
                gameObject.OnDestroy -= destroy;
            }
            gameObject.OnDestroy += destroy;
            return this;
        }


    }
}
