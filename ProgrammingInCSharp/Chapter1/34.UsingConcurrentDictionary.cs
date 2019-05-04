using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    class UsingConcurrentDictionary
    {
        public static void Run()
        {
            /*
            A ConcurrentDictionary stores key and value pairs in a thread-safe manner. 
            You can use methods to add and remove items, and to update items in place if they exist.

            When working with a ConcurrentDictionary you have methods that can atomically add, get, 
            and update items. An atomic operation means that it will be started and finished as a single 
            step without other threads interfering.
             */
            var dict = new ConcurrentDictionary<string, int>();
            if (dict.TryAdd("k1", 42))                          // k1 - 42
            {
                Console.WriteLine("Added");
            }
            if (dict.TryUpdate("k1", 21, 42))                   // k1 - 21
            {
                Console.WriteLine("42 updated to 21");
            }
            dict["k1"] = 42; // Overwrite unconditionally       // k1 - 42
            int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);// k1 - 24x2=84
            int r2 = dict.GetOrAdd("k2", 3);                    // k2 - 3         
            Console.WriteLine(r1);
            Console.WriteLine(r2);                  
        }
    }
}
