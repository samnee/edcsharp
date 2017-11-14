using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


// REF: https://www.cnblogs.com/henw/archive/2012/01/06/2314870.html

namespace ThreadPoolTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ManualResetEvent eventX = new ManualResetEvent(false);
            ThreadPool.SetMaxThreads(3,3);

            thr t = new thr(15, eventX);

            for(int i = 0; i < 15; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(t.ThreadProc), i);
            }

            eventX.WaitOne(Timeout.Infinite, true);
            Console.WriteLine("断点测试");
            Thread.Sleep(1000);
            Console.WriteLine("运行结束");

            Console.ReadKey();
        }

        public class thr
        {
            public thr(int count, ManualResetEvent mre)
            {
                iMaxCount = count;
                eventX = mre;              
            }

            public static int iCount = 0;
            public static int iMaxCount = 0;
            public ManualResetEvent eventX;

            public void ThreadProc(object i)
            {
                Console.WriteLine("Thread[" + i.ToString() + "]");
                Thread.Sleep(2000);

                Interlocked.Increment(ref iCount);

                if(iCount == iMaxCount)
                {
                    Console.WriteLine("发出结束信号");
                    eventX.Set();
                }
            }
        }
    }
}
