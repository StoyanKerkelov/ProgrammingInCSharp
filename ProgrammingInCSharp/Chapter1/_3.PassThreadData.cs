using System;
using System.Threading;
namespace Chapter1
{
    public static class PassThreadData
    {

        public static void ThreadMethod3(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }

        public static void Run()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod3));
            t.Start(5); // pass thread data
            t.Join();
        }
    }
}
