using System;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class TaskContinueWith
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
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });
            Console.WriteLine(t.Result);
            Console.ReadLine();
        }
    }
}