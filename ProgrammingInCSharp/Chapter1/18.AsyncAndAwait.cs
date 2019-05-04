using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chapter1
{
    internal class AsyncAndAwait
    {

        /*Asynchronous code solves this problem. Instead of blocking your thread until the I/O operation finishes,
         you get back a Task object that represents the result of the asynchronous operation. */

        public static void Run()
        {
            string result = DownloadContent().Result;
            Console.WriteLine(result);
        }
        /* You use the async keyword to mark a method for asynchronous operations. This way, you signal to the 
         compiler that something asynchronous is going to happen. The compiler responds to this by transforming
         your code into a state machine.*/
        public static async Task<string> DownloadContent()
        {

            /* Because the entry method of an application can’t be marked as async, the example uses the Wait method in Run().
             This class uses both the async and await keywords in the DownloadContent method. The GetStringAsync uses asynchronous 
             code internally and returns a Task<string> to the caller that will finish when the data is retrieved. In the meantime, 
             your thread can do other work. The nice thing about async and await is that they let the compiler do the thing it’s 
             best at: generate code in precise steps.*/

            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }
    }
}