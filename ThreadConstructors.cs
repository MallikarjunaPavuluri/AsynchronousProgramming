using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollectDetails
{
  class DataProcess
    {
        private double amount;
        readonly private String name;
        readonly private int id;
        public DataProcess(int id,String name,double amount)
        {
            this.id = id;
            this.name = name;
            this.amount = amount;
        }
        public void WithDraw(double amount)
        {
            if(this.amount>amount)
            {
                this.amount -= amount;
                Console.WriteLine($"Balance Amount After With Draw is-{this.amount}");
            }
            else
            {
                Console.WriteLine("InSufficient Balance");
            }
        }
        public void WithDrawSection()
        {
            Console.WriteLine("Enter Amount To With Draw");
            var samt = Console.ReadLine();
            double amt;
            if(double.TryParse(samt, out amt))
            {
                WithDraw(amt);
            }
        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            Thread t1 = new Thread(Method1)
            {
                Name = "Method1"
            };
            ThreadStart obj1 = new ThreadStart(Method2);
            Thread t2 = new Thread(obj1)
            {
                Name = "Method2"
            };
            Program p = new Program();
            ParameterizedThreadStart Pts = new ParameterizedThreadStart(Program.Method3);
            Thread t3 = new Thread(Pts)
            {
                Name = "Method3"
            };
            t1.Start();
            t2.Start();
            t3.Start("This is Mallikarjun");
            t3.Join();
            DataProcess d = new DataProcess(101, "Mallikarjuna", 30000);
            Thread c1 = new Thread(d.WithDrawSection);
            c1.Start();

        }

        private static void Method3(object n)
        {
            Console.WriteLine("Thread Name-" + Thread.CurrentThread.Name);
            Console.WriteLine("Parameter is " + n);
        }

        private static void Method2()
        {
            Console.WriteLine("Thread Name-" + Thread.CurrentThread.Name);
        }

        private static void Method1()
        {
            Console.WriteLine("Thread Name-" + Thread.CurrentThread.Name);
        }
    }
}
