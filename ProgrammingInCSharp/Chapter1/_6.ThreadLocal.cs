using System;
using System.Threading;

namespace Chapter1
{
    public static class TreadLocal
    {
        public static ThreadLocal<int> _field =
        new ThreadLocal<int>(() =>
        {
            return Thread.CurrentThread.ManagedThreadId;
            /*
             Thread.CurrentThread class to ask for information about the thread that’s executing.
             This is called the thread’s execution context. This property gives you access to properties like the 
             thread’s current culture (a CultureInfo associated with the current thread that is used to format dates, 
             times, numbers, currency values, the sorting order of text, casing conventions, and string comparisons), 
             principal (representing the current security context),  priority (a value to indicate how the thread 
             should be scheduled by the operating system), and other info.
             */
        });

        public static void Run()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread B: {0}", x);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}