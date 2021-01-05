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
            Monitor.Enter(LockThis);
            {
                n++;

                Console.WriteLine("Increment-" + n);
            }
            Monitor.Exit(LockThis);
        }
        public void Decrement()
        {
            Monitor.Enter(LockThis);
            {
                n--;

                Console.WriteLine("Decrement-" + n);
            }
            Monitor.Exit(LockThis);
        }
        public void Increment2()
        {
            Monitor.Enter(LockThis);
            {
                n += 2;

                Console.WriteLine("Increment2 - " + n);
            }
            Monitor.Exit(LockThis);
        }
        public void Decrement2()
        {
            Monitor.Enter(LockThis);
            {
                n -= 2;

                Console.WriteLine("Decrement2-" + n);
            }
            Monitor.Exit(LockThis);

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
