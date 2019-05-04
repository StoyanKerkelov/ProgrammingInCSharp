using System;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class ContinuationTasks
    {
        /*
        Because of the object-oriented nature of the Task object, one thing you can do is add a continuation task.
        This means that you want another operation to execute as soon as the Task finishes.
        */

        public static void Run()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);
            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            completedTask.Wait();
            Console.ReadLine();
        }
    }
}