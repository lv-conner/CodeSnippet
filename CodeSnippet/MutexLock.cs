using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CodeSnippet
{
    internal sealed class MutexLock
    {
        private readonly Mutex _mutexLock = new Mutex();
        public void Method1()
        {
            _mutexLock.WaitOne();
            Console.WriteLine("Method 1");
            Method2();
            _mutexLock.ReleaseMutex();

        }
        public void Method2()
        {
            _mutexLock.WaitOne();
            Console.WriteLine("Method 1");
            _mutexLock.ReleaseMutex();
        }
    }
}
