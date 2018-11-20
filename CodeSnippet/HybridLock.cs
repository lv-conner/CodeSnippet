using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CodeSnippet
{
    internal sealed class HybridLock
    {
        /// <summary>
        /// 等待者
        /// </summary>
        private int _waiters = 0;
        /// <summary>
        /// 等待锁
        /// </summary>
        private AutoResetEvent _waiterLock = new AutoResetEvent(false);
        /// <summary>
        /// 自旋时间
        /// </summary>
        private int _spinCount = 4000;
        /// <summary>
        /// 知名哪个线程拥有锁；
        /// </summary>
        private int _owningThreadId = 0;
        /// <summary>
        /// 
        /// </summary>
        private int _recusion = 0;
        public void Enter()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            //如果该线程拥有锁，递增计数。
            if(id == _owningThreadId)
            {
                _recusion++;
                return;
            }
            //该线程不持有该锁，尝试获取。
            SpinWait spinWait = new SpinWait();
            for (int i = 0; i < _spinCount; i++)
            {
                //CompareExchange将第一个和第三个进行比较，如果相等将第二个参数的值赋值给第一个参数，并返回第一个值的原始值
                if(Interlocked.CompareExchange(ref _waiters,1,0) == 0)  //如果_waiters==0;则标识当前等待者为0；表示该锁没有任何线程拥有，设置_waiter为1.获取该锁。
                {
                    //表示获取该锁成功；
                    goto GotLock;
                }
                //获取失败，给其他线程运行机会，希望锁会被释放。
                spinWait.SpinOnce();
            }
            //自旋结束，仍旧没有获取到锁，因此必须阻塞。
            if (Interlocked.Increment(ref _waiters) > 1)
            {
                _waiterLock.WaitOne();
            }
            GotLock:
            //设置线程拥有Id和拥有次数;
            _owningThreadId = id;
            _recusion++;
        }

        public void Leave()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            //如果调用线程不拥有锁，表示存在bug
            if(id != _owningThreadId)
            {
                throw new SynchronizationLockException("lock not owned by calling thread");
            }
            //递减递归计数，如果这个线程仍然拥有锁，直接返回
            if (--_recusion > 0)
            {
                return;
            }
            //递归计数为0。
            _owningThreadId = 0;
            //没有其他线程在等待，直接返回。
            if(Interlocked.Decrement(ref _waiters) == 0)
            {
                return;
            }
            //唤醒等待中的线程中的一个；
            _waiterLock.Set();
        }
    }
}
