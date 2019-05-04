using System;
using System.Threading;

namespace Chapter1
{
    public static class StopThreadProperly
    {
        public static void ThreadMethod4(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
        public static void Run()
        {
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));
            t.Start();
            /*The thread keeps running until stopped becomes true. After that, the t.Join method causes the console application
             to wait till the thread finishes execution.
             */

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            stopped = true;
            t.Join();
        }
    }
}