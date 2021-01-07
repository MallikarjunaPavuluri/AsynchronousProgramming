using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            try
            {
                Task t = Task.Run(() =>
                 {
                     Thread.Sleep(500);
                     Console.WriteLine("Hey Task Is Running Started");


                 }, ct);
                Thread.Sleep(1000);
                ts.Cancel();
                t.ContinueWith((i) =>
                {
                    Console.WriteLine("Task Faulted");
                }, TaskContinuationOptions.OnlyOnFaulted);

                t.ContinueWith((i) =>
                {
                    Console.WriteLine("Task Cancled");
                }, TaskContinuationOptions.OnlyOnCanceled);

                var task = t.ContinueWith((i) =>
                 {
                     Console.WriteLine("Task Completed");
                 }, TaskContinuationOptions.OnlyOnRanToCompletion);
                //Task.WaitAll(t, task);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }


    }
}
