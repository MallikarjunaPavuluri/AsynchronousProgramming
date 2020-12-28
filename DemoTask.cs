using System;
using System.Threading.Tasks;

namespace TaskDemo
{
     class DemoTask
    {
        internal  async  Task TaskPrint()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Welcome To Task");
                }
            });
            Console.WriteLine("Done With TaskPrint");
        }

        internal  async Task TaskPrintString()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("This is String");
                }
            });
            Console.WriteLine("Done With TaskPrint String");
        }
    }
    class Program
    {
        public static void Main(String []args)
        {
            DemoTask t = new DemoTask();
            var p1=t.TaskPrint();
            var p2=t.TaskPrintString();
            Task.WaitAny(p1, p2);
            Console.WriteLine($"p1.IsCompleted-{p1.IsCompleted}");
            Console.WriteLine($"p1.IsFaulted-{p1.IsFaulted}");
            Console.WriteLine($"p1.IsCanceled-{p1.IsCanceled}");
            Console.WriteLine($"p2.IsCompleted-{p2.IsCompleted}");
            Console.WriteLine($"p2.IsFaulted-{p2.IsFaulted}");
            Console.WriteLine($"p2.IsCanceled-{p2.IsCanceled}");

        }
    }
}
