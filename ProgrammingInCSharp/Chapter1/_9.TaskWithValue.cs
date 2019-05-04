using System;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class TaskWithValue
    {
        /*
        Task, which is an object that represents some work that should be done. The Task can 
        tell you if the work is completed and if the operation returns a result, the Task 
        gives you the result.
        */
        public static void Run()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });
            Console.WriteLine(t.Result); // Displays 42
            Console.ReadLine();
        }
    }
}