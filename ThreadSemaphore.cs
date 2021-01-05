using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollectDetails
{
  class Number
    {
        Semaphore sh = new Semaphore(1, 3);
        Mutex m = new Mutex();
        public static object LockThis = new object();
        String s = new string("Malli");
        
        public static int n;
        public Number(int N)
        {
            n = N;
        }
        public void Maniputate()
        {

            Console.WriteLine("Thread Out Before Side Name-" +Thread.CurrentThread.Name);
            sh.WaitOne();
            Console.WriteLine("Thread Inside Name-" + Thread.CurrentThread.Name);
            Thread.Sleep(1000);
            n++;
            Console.WriteLine("N-" + n);
            sh.Release();
            Console.WriteLine("Thread Out After Side Name-" + Thread.CurrentThread.Name);
        }
        
        
        
        
    }
    class Program
    {
        
        public static void Main(String[] args)
        {
            Number n = new Number(10);
            Thread t1 = new Thread(n.Maniputate);
            Thread t2 = new Thread(n.Maniputate);
            Thread t3 = new Thread(n.Maniputate);
            Thread t4 = new Thread(n.Maniputate);
            Thread t5 = new Thread(n.Maniputate);
            Thread t6 = new Thread(n.Maniputate);
            t1.Name = "Thread1";
            t2.Name = "Thread2";
            t3.Name = "Thread3";
            t4.Name = "Thread4";
            t5.Name = "Thread5";
            t6.Name = "Thread6";


            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
            Console.ReadLine();

        }

        
    }
}
