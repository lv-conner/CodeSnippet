using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CodeSnippet
{
    public class SimpleSpinLock
    { 
        public int _m_Resource_In_Use = 0;  //0标识锁未被使用，1标识锁已被使用。
        public void Enter()
        {
            while(true)
            {
                //Interlocked.Exchange方法的作用是，给指定值赋值，并返回原值。
                if(Interlocked.Exchange(ref _m_Resource_In_Use,1) == 0) //给_m_Resource_In_Use赋值为1，并返回原始值。因此在第一次第一个线程线程进入时能够返回，第二个线程则会自旋，直到第一个线程释放锁。
                {
                    return;
                }
            }
        }
        public void Leave() //释放锁，使用Volatile.Write方法。读取该变量的值的操作都必须在这个写入操作完成之后才能进行。因此，在写入值后，等待线程将获取到锁，继续执行。
        {
            Volatile.Write(ref _m_Resource_In_Use, 0);
        }
    }
}
