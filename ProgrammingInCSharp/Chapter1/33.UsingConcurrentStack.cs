using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    class UsingConcurrentStack
    {
        public static void Run()
        {
            /*
             ConcurrentQueue offers the methods Enqueue and TryDequeue to add and remove items from the collection. 
             It also has a TryPeek method and it implements IEnumerable by making a snapshot of the data. 
             Listing 1-33 shows how to use a ConcurrentQueue.
             */
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(42);
            int result;
            if (stack.TryPop(out result))
                Console.WriteLine("Popped: {0}", result);
            stack.PushRange(new int[] { 1, 2, 3 });
            int[] values = new int[2];
            stack.TryPopRange(values);
            foreach (int i in values)
                Console.WriteLine(i);
        }
    }
}
