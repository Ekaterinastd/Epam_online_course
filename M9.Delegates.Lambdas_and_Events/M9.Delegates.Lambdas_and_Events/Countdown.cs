using System;
using System.Threading;

namespace M9.Delegates.Lambdas_and_Events
{
    class Subscriber
    {
        public Subscriber(string name)
        {
            Name = name;
        }

        string Name { get; set; }

        public void Message()
        {
            Console.WriteLine("Time is over: " + Name);
        }
    }

    /// <summary>
    /// Обратный отсчёт
    /// </summary>
    class Countdown
    {
        public int Interval { get; set; }
        public event Action Tick;

        public void Start()
        {
            Thread.Sleep(Interval * 1000);
            Tick();
        }
    }
       
   
}
