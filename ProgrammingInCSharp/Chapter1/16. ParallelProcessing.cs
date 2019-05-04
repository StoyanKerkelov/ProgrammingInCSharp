using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class ParallelProcessing
    {
        public static void Run()
        {
            /* You should use the Parallel class only when your code doesn’t have to be executed sequentially.
            Increasing performance with parallel processing happens only when you have a lot of work to be done
            that can be executed in parallel.For smaller work sets or for work that has to synchronize access 
            to resources, using the Parallel class can hurt performance.*/

           // Parallel.For
           Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            });
            var numbers = Enumerable.Range(0, 10);

            // Parallel.ForEach
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
            });
        }
    }
}