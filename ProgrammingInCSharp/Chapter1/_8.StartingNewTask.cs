using System;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class StartingNewTask
    {
        /*
        Task, which is an object that represents some work that should be done. The Task can 
        tell you if the work is completed and if the operation returns a result, the Task 
        gives you the result.
        */
        public static void Run()
        {
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 100; x++)
                {
                    Console.Write('*');
                }
            });
            t.Wait();
        }
    }
}