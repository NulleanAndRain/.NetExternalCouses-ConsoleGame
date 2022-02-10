using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public class Input
    {
        private static Input? _instance;
        public static Input Instance => _instance ??= new Input();

        private volatile char _key;
        public static char Key => Instance._key;

        private Thread _thread;

        public Input()
        {
            _thread = new Thread(ReadConsole);
        }

        private void ReadConsole()
        {
            while (true)
            {
                _key = Console.ReadKey(true).KeyChar;
            }
        }
    }
}
