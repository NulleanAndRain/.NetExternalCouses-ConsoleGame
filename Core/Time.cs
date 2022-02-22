using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulleanAndRain.ConsoleGame.Core
{
    public static class Time
    {
        public static event Action OnGameTick = delegate { };

        public const int MinFrameTime = 50;

        private struct Subscription
        {
            public DateTime StartTime;
            public DateTime EventTime;
            public Action Event;

            public Subscription(DateTime startTime, double eventTime, Action @event)
            {
                StartTime = startTime;
                EventTime = startTime + TimeSpan.FromSeconds(eventTime);
                Event = @event;
            }
        }

        private static List<Subscription> _subscriptions = new();

        public static void Start()
        {
            DateTime startTime;
            while (true)
            {
                startTime = DateTime.Now;
                OnGameTick();
                var unsubscribeList = new List<Subscription>();
                foreach (var subscription in _subscriptions)
                {
                    if (subscription.EventTime >= DateTime.Now)
                    {
                        subscription.Event();
                        unsubscribeList.Add(subscription);
                    }
                }
                foreach(var sub in unsubscribeList)
                {
                    _subscriptions.Remove(sub);
                }
                Thread.Sleep(Math.Max(0, MinFrameTime - (DateTime.Now - startTime).Milliseconds));
            }
        }

        public static void DoAfterTime(Action action, double time)
        {
            _subscriptions.Add(new Subscription(DateTime.Now, time, action));
        }
    }
}
