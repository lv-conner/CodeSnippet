using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CodeSnippet.DesignPattern
{
    /// <summary>
    /// 单例模式
    /// 单例模式要求指定类型在全局只有一个实例。
    /// </summary>
    public class Singleton
    {
        /// <summary>
        /// 以静态实例对外暴露唯一的实例。readonly指示该实例不能修改为null;
        /// 适用类型构造器来构造唯一实例，该实例由CLR在装载该类型时自动构造，CLR确保在调用类型构造器时只有一个线程访问。因此这个单例时线程安全的。
        /// 缺点：由于是使用CLR装载时构造，因此会在加载该类型时就调用，如果该单例时一个大的对象，但是在代码中没有调用到。则可能导致内存浪费。
        /// </summary>
        public static readonly Singleton Instanse = new Singleton();
        /// <summary>
        /// 延迟构造。仅在调用时才构造该类型的单例。由于存在多个线程同时访问，因此需要使用锁进行线程同步，可以考虑使用
        /// </summary>
        public static object _instanseLock = new object();
        public static Singleton AnotherInstanse
        {
            get
            {
                //避免每次访问单例时都需要加锁。
                if(_anotherInstanse != null)
                {
                    return _anotherInstanse;
                }
                lock(_instanseLock)
                {
                    if(_anotherInstanse == null)
                    {
                        var temp = new Singleton();
                        Volatile.Write(ref _anotherInstanse, temp);//避免在构造器尚未调用完成而有其他线程访问该单例
                    }
                    return _anotherInstanse;
                }
            }
        }
        private static Singleton _anotherInstanse;
        public string Name { get; set; }
        /// <summary>
        /// 将构造器设置为private，将导致外部无法构造新的实例。
        /// </summary>
        private Singleton()
        {

        }
    }

    public class SingletonCase
    {
        private SingletonCase()
        {

        }

        private static SingletonCase _singletonCase;
        public static SingletonCase Singleton
        {
            get
            {
                if(_singletonCase != null)
                {
                    return _singletonCase;
                }
                var temp = new SingletonCase();
                Interlocked.CompareExchange(ref _singletonCase, temp, null);//可能创建多个实例，但是最终只有一个实例被设置到引用中；
                //优点：没有锁，但是速度非常快。而且不会阻塞线程。
                return _singletonCase;
            }
        }
    }
}
