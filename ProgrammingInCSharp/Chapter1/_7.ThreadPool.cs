using System;
using System.Threading;

namespace Chapter1
{
    public static class TreadPool
    {
        /*
        The creation of a thread, however, is something that costs some time and resources. A thread pool is created to 
        reuse those threads, similar to the way a database connection pooling works. Instead of letting a thread die, 
        you send it back to the pool where it can be reused whenever a request comes in.
        */
        public static void Run()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });
            Console.ReadLine();
        }
    }
}