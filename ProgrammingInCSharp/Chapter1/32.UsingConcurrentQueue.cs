using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    class UsingConcurrentQueue
    {
        public static void Run()
        {
            /*
             ConcurrentQueue offers the methods Enqueue and TryDequeue to add and remove items from the collection. 
             It also has a TryPeek method and it implements IEnumerable by making a snapshot of the data. 
             Listing 1-33 shows how to use a ConcurrentQueue.
             */
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);
            int result;
            if (queue.TryDequeue(out result))
                Console.WriteLine("Dequeued: {0}", result);
        }
    }
}
