namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;

    /**
     * Problem 7. Timer & Problem 8.* Events
     * Using delegates write a class Timer that can execute certain method at each t seconds.
     * Read in MSDN about the keyword event in C# and how to publish events.
     * Re-implement the above using .NET events and following the best practices.
     */
    public class HomeworkTimer
    {
        private event Action OneSecond;

        private readonly Timer timer;

        private readonly ICollection<Action> oneTimeActions;

        public HomeworkTimer()
        {
            this.timer = new Timer { Interval = 1000 };
            this.timer.Elapsed += this.OnOneSecond;
            this.oneTimeActions = new HashSet<Action>();
        }

        public bool IsRunning => this.timer.Enabled;

        public HomeworkTimer Start()
        {
            this.timer.Start();
            return this;
        }

        public HomeworkTimer Stop()
        {
            this.timer.Stop();
            return this;
        }

        /// <summary>
        /// Subscribe a method to be called each second once the timer is started
        /// </summary>
        /// <param name="callback">A void method without arguments</param>
        public HomeworkTimer Subscribe(Action callback)
        {
            this.OneSecond += callback;
            return this;
        }

        public HomeworkTimer SubscribeOnce(Action callback)
        {
            this.oneTimeActions.Add(callback);
            return this;
        }

        public HomeworkTimer Unsubscribe(Action callback)
        {
            this.OneSecond -= callback;
            this.oneTimeActions.Remove(callback);
            return this;
        }

        protected virtual void OnOneSecond(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            this.OneSecond?.Invoke();
            this.FireOneTimeActions();
        }

        private void FireOneTimeActions()
        {
            if (this.oneTimeActions.Count == 0)
            {
                return;
            }

            Action[] actions;

            lock (this.oneTimeActions)
            {
                actions = this.oneTimeActions.ToArray();
                this.oneTimeActions.Clear();
            }

            foreach (var action in actions)
            {
                action();
            }
        }
    }
}
