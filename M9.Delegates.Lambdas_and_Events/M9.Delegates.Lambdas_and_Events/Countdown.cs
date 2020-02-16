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
       
    public class Program
    {
        public static void Main()
        {
            var s1 = new Subscriber("S1");
            var s2 = new Subscriber("S2");
            var s3 = new Subscriber("S3");

            var c = new Countdown() { Interval = 3 };
            c.Tick += s1.Message;
            c.Tick += s2.Message;
            c.Tick += s3.Message;
            c.Start();
            c.Tick -= s1.Message;
            c.Start();
            Console.ReadKey();
        }
    }
}
