using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    class ParallelLINQ
    {
        public static void Run()
        {
            var numbers = Enumerable.Range(0, 1000);
            var parallelResult = numbers.AsParallel()
            //.AsOrdered() // to order result
            .AsSequential() // operator to make sure that the Take method doesn’t mess up your order.
            .Where(i => i % 2 == 0)
            .ToArray();
            foreach (int i in parallelResult)
                Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}
