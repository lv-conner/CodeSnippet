using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CodeSnippet
{
    public class MonitorySample
    {
        private static object _lock = new object();
        public static void Case()
        {
            lock (_lock)
            {
                Console.WriteLine("First got lock");
                lock (_lock)
                {
                    Console.WriteLine("Second got lock");
                }
            }
            //=>
            bool lockTaken = false;
            try
            {
                Monitor.Enter(_lock, ref lockTaken);

            }
            finally
            {
                if (lockTaken) Monitor.Exit(_lock);
            }

        }

        public static void RecommandedCase()
        {
            Monitor.Enter(_lock);
            Console.WriteLine("First got lock");
            Monitor.Enter(_lock);
            Console.WriteLine("Secodn got lock");
            Monitor.Exit(_lock);
            Monitor.Exit(_lock);
        }

    }
}
