using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Singleton
{
    /*
    Definition:
        Singleton is a creational design pattern that lets you ensure that a class has only one instance, while providing a global access point to this instance.
    Problem:
        The Singleton pattern solves two problems at the same time, violating the Single Responsibility Principle:
        1) Ensure that a class has just a single instance.
        2) Provide a global access point to that instance.
    Pros: 
        1) You can be sure that a class has only a single instance.
        2) You gain a global access point to that instance.
        3) The singleton object is initialized only when it’s requested for the first time.
    Cons: 
        1) Violates the Single Responsibility Principle. The pattern solves two problems at the time.
        2) The pattern requires special treatment in a multithreaded environment so that multiple threads won’t create a singleton object several times.
    */
    public sealed class Singleton
    {
        private Singleton() { }
        private static Singleton _instance;
        private static readonly object _lock = new object();
        public static Singleton GetInstance(string value)
        {
            if(_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                        _instance.value = value;
                    }
                }
            }
            return _instance;
        }

        public string value { get; set; }
    }


    class program
    {
        static void Main(string[] args)
        {
            Thread process1 = new Thread(() =>
            {
                TestSingleton("Kamrul");
            });

            Thread process2 = new Thread(() =>
            {
                TestSingleton("Hasan");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();

            static void TestSingleton(string value)
            {
                Singleton s = Singleton.GetInstance(value);
                Console.WriteLine(s.value);
            }
            

           /* Singleton s1  = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            if(s1 == s2)
            {
                Console.WriteLine("Singleton works");
            }
            else
            {
                Console.WriteLine("Singleton failed");
            }*/
        }
    }
}
