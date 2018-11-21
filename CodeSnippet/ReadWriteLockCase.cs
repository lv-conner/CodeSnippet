using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace CodeSnippet
{
    internal sealed class ReadWriteLockCase
    {
        static ReaderWriterLockSlim _readerWriterLockSlim = new ReaderWriterLockSlim();
        static string Name = "tim lv";
        static string Read()
        {
            _readerWriterLockSlim.EnterReadLock();
            var s =  Name;
            _readerWriterLockSlim.ExitReadLock();
            return s;
        }
        static void Write(string s)
        {
            _readerWriterLockSlim.EnterWriteLock();
            Name = s;
            _readerWriterLockSlim.ExitWriteLock();
        }
    }
}
