using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeSnippet
{
    class Program
    {
        static void Main(string[] args)
        {
            //TranslocationOperate();
            //MemoryStreamCase();

            Task.Run(() =>
            {
                LockPersonType();
            });
            Thread.Sleep(100);
            var p = new Person();
            var ptype = typeof(Person);


            Console.ReadKey();
            //old();
        }
        public static void LockPersonType()
        {
            Monitor.Enter(typeof(Person));
            Thread.Sleep(10000);
            Monitor.Exit(typeof(Person));
        }

        private static void old()
        {
            ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim();
            Task.Delay(2000).ContinueWith(t =>
            {
                manualResetEventSlim.Set();
            });
            manualResetEventSlim.Wait();
            var a1 = 10;
            var v = Interlocked.CompareExchange(ref a1, 1, 5);
            MutexLock mutexLock = new MutexLock();
            mutexLock.Method1();

            Semaphore semaphore = new Semaphore(1, 2);
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            Mutex mutex = new Mutex();
            Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Task Compelte");
                autoResetEvent.Set();
            });
            autoResetEvent.WaitOne();
            Console.WriteLine("Auto Reset Event recevied a signal");
            semaphore.WaitOne();

            Task.Run(() =>
            {
                semaphore.WaitOne();
                Console.WriteLine("Task complete");
            });
            Task.Run(() =>
            {
                semaphore.WaitOne();
                Console.WriteLine("2 task compelte");
            });


            var a = semaphore.Release(2);
            var b = semaphore.Release(1);
            var c = semaphore.Release(2);


            Console.ReadKey();
            int value = 0;
            var value2 = Interlocked.Exchange(ref value, 1);
            var k = false ^ false;
            Console.WriteLine("Hello World!");
        }

        static void ManualResetEventSlimCase()
        {
        }


        public class Person
        {
            public ReaderWriterLockSlim _readerWriterLockSlim = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
            public string Id { get; set; }
            public Person()
            {
                Id = Guid.NewGuid().ToString();
            }
            public void Read()
            {
                _readerWriterLockSlim.EnterReadLock();
                Console.WriteLine(Id);
            }
            public void Write(string id)
            {
                _readerWriterLockSlim.EnterWriteLock();
                Id = id;
            }
        }

        static void MutexCase()
        {
            Mutex mutex = new Mutex();
        }
        /// <summary>
        /// 移位运算
        /// </summary>
        static void TranslocationOperate()
        {
            var a = 4; //100;
            var b = a >> 1;//向右移动1位，100
            Debug.Assert(b == 2);
            var c = a << 1;//向左移动1位：1000；
            Debug.Assert(c == 8);

        }
        /// <summary>
        /// 提供对内存字节的流式读写。
        /// </summary>
        static void MemoryStreamCase()
        {
            var msgByte = Encoding.UTF8.GetBytes("Hello World");
            MemoryStream buff = new MemoryStream(msgByte);
            var r1 = buff.ReadByte();
            var r2 = buff.ReadByte();
            var c = (char)r1;
            var d = (char)r2;
            Console.ReadKey();
            Func<object, ArgumentException> fn1 = Case1;
            Func<string, Exception> fn2 = Case1;

            Func<MemoryStream, Stream> fn3 = Case;
            Hello<MemoryStream, Stream> fn4 = Case;
            Hello<MemoryStream, object> fn5 = GetString;
            List<Stream> streams = null;
            List<MemoryStream> memoryStreams = new List<MemoryStream>();
            GetValue<Stream>(new MemoryStream());

        }

        static void GetValue<TIn>(TIn inValue)
        {
            TIn @in = default(TIn);
        }

        static ArgumentException Case1(object state)
        {
            return new ArgumentException();
        }
        static MemoryStream Case(Stream stream)
        {
            return new MemoryStream();
        }

        static string GetString(Stream stream)
        {
            return "Hello";
        }
    }

    public delegate TResult Hello<in T,out TResult>(T arg);
}
