using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollectDetails
{

    class Program
    {
        class TaskDemo
        {
            private String s;
            private int vowels;
            public TaskDemo(String s)
            {
                this.s = s;
                vowels = 0;
            }
          public  int Count()
            {
                s = "Mallikarjuna";
                var t = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"Count Id-{t}");
                return s.Length;
            }
            public  int Vowel()
            {
                for(int i=0;i<s.Length;i++)
                {
                    if(s[i]=='a'||s[i]=='e'|| s[i] == 'i' || s[i] == 'o' || s[i] == 'u' )
                    {
                        vowels++;
                    }
                }
                var t = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"Vowels Id-{t}");
                return vowels;
            }
        }
        public static void Main(String[] args)
        {
            TaskDemo t = new TaskDemo("Mallikarjuna");
            Func<int>  a = t.Count;
            Func<int>  b = t.Vowel;
            Task<int> p1 = new Task<int>(a);
            Task<int> p2 = new Task<int>(b);
            p1.Start();
            p2.Start();
            var p = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Vowels Id-{p}");
            Console.WriteLine(p1.Result);
            Console.WriteLine(p2.Result);
        }  
    }
}
