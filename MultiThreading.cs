using System;
using System.Threading;

namespace ConsoleApp2
{
      class Exam
    {
        bool[] qn = { false, false, false, false, false };
        private string name;
        private int marks;
        

         public Exam(string input)
        {
            this.name = input;
        }

        public  void StartExam()
        {
            var input = " ";
            Console.WriteLine($"{name}Enter Yes/No for Questions You Know: ");
            for (int i=0;i<5;i++)
            {
                Console.WriteLine($"{name} Do You Answer For {i+1} Question-");
                input = Console.ReadLine();
                if((input.ToLower()).Equals("yes"))
                {
                    qn[i] = true;
                }
                Console.WriteLine($"{name} Your Ans for {i+1} q is {qn[i]}");
            }
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Console.WriteLine("Enter Name-");
            var input = Console.ReadLine();
            Exam a = new Exam(input);
            Console.WriteLine("Enter Name-");
            input = Console.ReadLine();
            Exam b = new Exam(input);
            Console.WriteLine("Enter Name-");
            input = Console.ReadLine();
            Exam c = new Exam(input);
            ThreadStart a1 = a.StartExam;
            ThreadStart b1 = b.StartExam;
            ThreadStart c1 = c.StartExam;


            //ThreadStart AtaTime = a1 + b1 + c1;
             Thread main1 = new Thread(a1);

            Thread main2 = new Thread(b1);

            Thread main3 = new Thread(c1);
            if (n==0)
            {
                main1.Start();
                main1.Join();
                main2.Start();
                main2.Join();
                main3.Start();
            }

        }
    }
}
