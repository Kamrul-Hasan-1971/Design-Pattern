using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Singleton
{
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
