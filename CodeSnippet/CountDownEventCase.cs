using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CodeSnippet
{
    internal sealed class CountDownEventCase
    {
        static void Case1()
        {
            CountdownEvent countdownEvent = new CountdownEvent(2);
            countdownEvent.AddCount();
            countdownEvent.Signal(2);
        }
    }
}
