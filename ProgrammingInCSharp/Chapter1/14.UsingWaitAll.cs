using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class UsingWaitAll
    {
        /*
        You can use the method WaitAll to wait for multiple Tasks to finish before continuing execution.
        */

        public static void Run()
        {
            // All three Tasks are executed simultaneously, and the whole run takes approximately 1000ms instead of 3000.
            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            }
            );
            Task.WaitAll(tasks);

            Console.ReadLine();
        }
    }
}