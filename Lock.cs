using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
        public void Increment()
        {
            lock (LockThis)
            {
                n++;

                Console.WriteLine("Increment-" + n);
            }
        }
        public void Decrement()
        {
            lock (LockThis)
            {
                n--;

                Console.WriteLine("Decrement-" + n);
            }
        }
        public void Increment2()
        {
            lock (LockThis)
            {
                n += 2;

                Console.WriteLine("Increment2 - " + n);
            }
        }
        public void Decrement2()
        {
            lock (LockThis)
            {
                n -= 2;

                Console.WriteLine("Decrement2-" + n);
            }

        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            Number n = new Number(10);
            Thread t1 = new Thread(n.Increment);
            Thread t2 = new Thread(n.Decrement);
            Thread t3 = new Thread(n.Increment2);
            Thread t4 = new Thread(n.Decrement2);
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
           

        }

        
    }
}
