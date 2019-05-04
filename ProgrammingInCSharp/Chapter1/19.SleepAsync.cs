using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    class SleepAsync
    {

        /* The SleepAsyncA method uses a thread from the thread pool while sleeping. The second method, 
        however, which has a completely different implementation, does not occupy a thread while waiting
        for the timer to run. 
        
        The second method gives you scalability. When using the async and await  keywords, you should 
        keep this in mind. Just wrapping each and every operation in a task and awaiting them won’t 
        make your application perform any better. It could, however, improve responsiveness, which is
        very important in client applications.*/

        public Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }
        public Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            return tcs.Task;
        }
    }
}
