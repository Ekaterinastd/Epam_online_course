using System;

namespace M9.Delegates.Lambdas_and_Events
{
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
