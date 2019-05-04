using System;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class ChildTasks
    {
        /*
        The finalTask runs only after the parent Task is finished, and the parent Task finishes when 
        all three children are finished. You can use this to create quite complex Task hierarchies 
        that will go through all the steps you specified.
        */

        public static void Run()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                new Task(() => results[0] = 0,
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1,
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2,
                TaskCreationOptions.AttachedToParent).Start();
                return results;
            });
            var finalTask = parent.ContinueWith(
            parentTask =>
            {
                foreach (int i in parentTask.Result)
                    Console.WriteLine(i);
            });
            finalTask.Wait();
            Console.ReadLine();
        }
    }
}