using System;
using System.Threading;
namespace MoneyTransfer
{
    class Customer
    {
        public double Amount
        {
            get;
            set;
        }
        public String Name
        {
            get;
        }
        public int Id
        {
            get;
        }
        public Customer(int id, String name, double amount)
        {
            this.Id = id;
            this.Name = name;
            this.Amount = amount;
        }

        public void WithDraw(double amount)
        {
            if (this.Amount > amount)
            {
                this.Amount -= amount;
                
            }
            else
            {
                Console.WriteLine("InSufficient Balance");
            }
        }
        public void Deposit(double amount)
        {
            this.Amount += amount;
        }
        public void Display()
        {
            Console.WriteLine($"{Name} Account Balance {Amount}");
        }
    }
    class IMPS
    {
        private Customer DebitAccount;
        private Customer CreditAccount;
        private double amount;
        public IMPS(Customer Dbt, Customer Crdt, double d)
        {
            DebitAccount = Crdt;
            CreditAccount = Dbt;
            amount = d;
        }
        public void FundTransfer()
        {
            object lock1, lock2;
            if (CreditAccount.Id > DebitAccount.Id)
            {
                lock1 = CreditAccount;
                lock2 = DebitAccount;
            }
            else
            {
                lock2 = CreditAccount;
                lock1 = DebitAccount;
            }
            lock (lock1)
            {
                lock (lock2)
                {
                    DebitAccount.WithDraw(amount);
                    CreditAccount.Deposit(amount);
                    Console.WriteLine($"Money Transfer From {DebitAccount.Name} amount of {amount} Current " +
                        $"Balance {DebitAccount.Amount} to {CreditAccount.Name} Current Balance {CreditAccount.Amount} ");
                }
            }

        }
    }
    class Program
    {
        public static void Main(String[]args)
        {
            Customer c1 = new Customer(101, "Arjun", 20000);
            Customer c2 = new Customer(102, "Kumar", 30000);
            IMPS Transfer1 = new IMPS(c1, c2, 10000);
            Thread t1 = new Thread(Transfer1.FundTransfer)
            {
                Name = "Thread1"
            };
            t1.Start();
            
            //c1.Display();
            //c2.Display();
            IMPS Transfer2 = new IMPS(c2, c1, 5000);
            Thread t2 = new Thread(Transfer2.FundTransfer)
            {
                Name = "Thread2"
            };
            t2.Start();
            //c1.Display();
            //c2.Display();

        }
    }
}
