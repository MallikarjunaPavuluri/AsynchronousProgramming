using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
    public static void Main()
    {
        var tbid = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine($"Main Thread Before Task-{tbid}");
        Task t = new Task(() =>
         {
             var tid = Thread.CurrentThread.ManagedThreadId;
             Console.WriteLine($"Task Started With Thread Id-{tid}");
         });
        t.Start();
        var taid = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine($"Main Thread After Task-{taid}");
    }
}
