using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    class CatchAggregateException
    {
        public static void Run()
        {
            var numbers = Enumerable.Range(0, 20);
            try
            {
                var parallelResult = numbers.AsParallel()
                .Where(i => IsEven(i));
                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count);

                foreach(Exception ex in e.InnerExceptions)
                {
                    Console.WriteLine(ex.GetType() + " " +ex.Message);
                }
            }

        }
        public static bool IsEven(int i)
        {
            if (i % 10 == 0) throw new ArgumentException("i"); //generate exception
            return i % 2 == 0;

        }
    }
}
