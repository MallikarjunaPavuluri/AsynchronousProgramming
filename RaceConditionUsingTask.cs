using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CollectDetails
{
    class Number
    {
        public static object LockThis = new object();
        public static int n;
        public Number(int N)
        {
            n = N;
        }
        public async Task Increment()
        {
            await Task.Run(() => 
            {
                lock (LockThis)
                {
                    n++;

                    Console.WriteLine("Increment-" + n);
                }
            });
            
               
            
        }
        public async Task Decrement()
        {
            await Task.Run(() =>
            {
                lock (LockThis)
                {
                    n--;

                    Console.WriteLine("Decrement--" + n);
                }
            });
        }
        public async Task Increment2()
        {
            await Task.Run(() =>
            {
                lock (LockThis)
                {
                    n += 2;

                    Console.WriteLine("Increment2-" + n);
                }
            });
        }
        public async Task Decrement2()
        {
            await Task.Run(() =>
            {
                lock (LockThis)
                {
                    n -= 2;

                    Console.WriteLine("Decrement2-" + n);
                }
            });

        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
           Number n = new Number(10);
           var Watch= Stopwatch.StartNew();
           var p1=  n.Increment();
           var p2= n.Decrement();
           var p3=n.Decrement2();
           var p4=n.Increment2();
           Task.WaitAny(p1, p2, p3, p4);
           var time = Watch.ElapsedMilliseconds;
           Console.WriteLine("Time Elapsed -" + time+"ms");
            


        }


    }
}
