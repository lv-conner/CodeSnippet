using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text;

namespace CodeSnippet
{
    class Program
    {
        static void Main(string[] args)
        {
            //TranslocationOperate();
            //MemoryStreamCase();
            var k = false ^ false;
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
        }
    }
}
