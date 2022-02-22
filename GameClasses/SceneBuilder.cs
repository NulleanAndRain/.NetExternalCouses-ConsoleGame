using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NulleanAndRain.ConsoleGame.Core;
using NulleanAndRain.ConsoleGame.GameClasses.StaticSceneObjects;

namespace NulleanAndRain.ConsoleGame.GameClasses
{
    public static class SceneBuilder
    {
        private class Constants
        {
            // public const char 
            public const char PlayerSymbol = 'v';
            public const char ObstacleSymbol = '#';
            public const char DisappearingBonus = 'o';
            public const char HealthBonus = '+';
        }


        public static Scene ReadSceneFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();
            var camera = new Camera();
            Scene scene = new(camera);

            Player? player = null;

            var lines = File.ReadAllLines(path);

            for (int row = 0; row < lines.Length; row++)
            {
                var line = lines[row];
                for (int col = 0; col < line.Length; col++)
                {
                    switch (char.ToLower(line[col]))
                    {
                        case Constants.PlayerSymbol:
                            {
                                player = new Player(new Point(col, row));
                                camera.MoveAfter = player;

                                scene.LastRenderableObj = player;
                                //scene.AddGameObject(player);
                                break;
                            }
                        case Constants.ObstacleSymbol:
                            {
                                var obj = new Obstacle(new Point(col, row));

                                scene.AddGameObject(obj);
                                break;
                            }
                        case Constants.DisappearingBonus:
                            {
                                var obj = new DisappearingBonus(new Point(col, row));

                                scene.AddGameObject(obj);
                                break;
                            }
                        case Constants.HealthBonus:
                            {
                                var obj = new HealthBonus(new Point(col, row));

                                scene.AddGameObject(obj);
                                break;
                            }
                        case ' ':
                        default: break;
                    }
                }
            }

            return scene;
        }
    }
}
