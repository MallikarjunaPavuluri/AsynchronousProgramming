using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollectDetails
{

    class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Main Method Started");
            var tid = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Main Method With id-{tid}");
            M10SecMethod();
            M20SecMethod();
            M30SecMethod();
            Thread.Sleep(32000);
            Console.WriteLine("Main Method Completed");
        }

        private  static async void M30SecMethod()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(30000);
            });
            var tid = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"M30SecMethod Completed With id-{tid}");
        }

        private async static void M20SecMethod()
        {
           await Task.Run(() =>
            {
                Thread.Sleep(20000);
            });
            var tid = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"M20SecMethod Completed With id-{tid}");
        }

        private  static async void M10SecMethod()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(10000);
            });
            var tid = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"M10SecMethod Completed With id-{tid}");
        }
    }
}
