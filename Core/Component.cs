﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public abstract class Component
    {
        public abstract void Update();

        public readonly GameObject gameObject;

        protected Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public T? GetComponent<T>() where T : Component => gameObject.GetComponent<T>();
    }
}