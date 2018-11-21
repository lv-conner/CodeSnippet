using System;
using Xunit;
using CodeSnippet;

namespace CodeSnippet.Test
{
    public class UnitTest1
    {
        [Fact]
        public void BubbleSort()
        {
            var arr = Algorithms.SelectSort(true,2, 3, 4, 6, 78, 9, 0, 0);
            Assert.True(arr[7] == 78);
        }

        [Fact]
        public void TestMonitorLock()
        {
            MonitorySample.Case();
            MonitorySample.RecommandedCase();
        }

    }
}
