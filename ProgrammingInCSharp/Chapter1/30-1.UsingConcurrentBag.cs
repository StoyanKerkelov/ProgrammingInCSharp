using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    class UsingConcurrentBag
    {
        public static void Run()
        {
            /*
             A ConcurrentBag is just a bag of items. It enables duplicates and it has no particular order.
             Important methods are Add, TryTake, and TryPeek.
             */
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(42);
            bag.Add(21);
            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);
            if (bag.TryPeek(out result))
                Console.WriteLine("There is a next item: {0}", result);

            ConcurrentBag<int> bag2 = new ConcurrentBag<int>();
            Task.Run(() =>
            {
                bag2.Add(42);
                Thread.Sleep(1000);
                bag2.Add(21);
            });
            Task.Run(() =>
            {
                /*
                 This code only displays 42 because the other value is added after iterating over the bag
                    has started.
                 */
                foreach (int i in bag)
                    Console.WriteLine(i);
            }).Wait();

        }
    }
}
