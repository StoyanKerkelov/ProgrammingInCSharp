using System;
using System.Threading;
namespace Chapter1
{
    public static class BackgroundThread
    {

        public static void ThreadMethod2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }

        public static void Run()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod2));
            t.IsBackground = true;
            //If you run this application with the IsBackground property set to true, the application exits immediately.
            t.IsBackground = false;
            //If you set it to false (creating a foreground thread), the application prints the ThreadProc message ten times.
            t.Start();
        }
    }
}
