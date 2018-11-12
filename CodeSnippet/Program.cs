using System;
using System.Diagnostics;
using System.Threading;

namespace CodeSnippet
{
    class Program
    {
        static void Main(string[] args)
        {
            TranslocationOperate();
            Console.WriteLine("Hello World!");
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
    }
}
