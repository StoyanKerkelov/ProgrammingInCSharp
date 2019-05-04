using System;
using System.Threading.Tasks;

namespace Chapter1
{
    internal class ParallelStop
    {
        /* You can cancel the loop by using the ParallelLoopState object. You have two options to do this:
         Break or Stop. Break ensures that all iterations that are currently running will be finished. */

        public static void Run()
        {
            ParallelLoopResult result = Parallel.
            For(0, 1000, (int i, ParallelLoopState loopState) =>
            {
                if (i == 500)
                {
                    Console.WriteLine("Breaking loop");
                    loopState.Break();
                }
                return;
            });
        }
    }
}