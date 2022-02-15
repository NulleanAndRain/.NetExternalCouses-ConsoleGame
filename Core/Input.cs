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

        #region constants

        public static class Constants
        {
            // public const char 
            public const char EmptyKey = '\0';
            public const char KeyUp = 'w';
            public const char KeyRight = 'd';
            public const char KeyDown = 's';
            public const char KeyLeft = 'a';

            public const char KeyAttack = ' ';
        }

        #endregion

        public static char Key
        {
            get
            {
                var temp = Instance._key;
                Instance._key = Constants.EmptyKey;
                return temp;
            }
        }

        private Thread _thread;

        public Input()
        {
            _thread = new Thread(ReadConsole);
            _thread.Start();
        }

        private void ReadConsole()
        {
            while (true)
            {
                _key = char.ToLower(Console.ReadKey(true).KeyChar);
            }
        }
    }
}
