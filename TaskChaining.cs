using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamResults
{
    class Program
    {
        static void Main(string[] args)
        {

            Task t = Task.Run(() =>
             {
                 Console.WriteLine("Hey Task Is Running Started");
                   
             });
              

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Task Faulted");
            },TaskContinuationOptions.OnlyOnFaulted);

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Task Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            var task = t.ContinueWith((i) =>
             {
                 Console.WriteLine("Task Completed");
             },TaskContinuationOptions.OnlyOnRanToCompletion);


        }


    }
}
