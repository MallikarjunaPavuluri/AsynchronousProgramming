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
            M10SecMethod();
            M20SecMethod();
            M30SecMethod();
            Thread.Sleep(32000);
            Console.WriteLine("Main Method Completed");
        }

        private async static void M30SecMethod()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(30000);
            });
            Console.WriteLine("M30SecMethod Completed");
        }

        private async static void M20SecMethod()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(20000);
            });
            Console.WriteLine("M20SecMethod Completed");
        }

        private async static void M10SecMethod()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(10000);
            });
            Console.WriteLine("M10SecMethod Completed");
        }
    }
}
