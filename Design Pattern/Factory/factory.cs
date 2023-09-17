using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Factory
{
    /*
    * It is a creational design pattern that solves problems while creating the objects.
    * It provides a factory and using that factory we request for object instead of directly creating it.
     * 1) It hides the logic for instantiation.
     * 2) Reduce the duplicity of code.
     * 3) One place change will change everywhere
     */

    public interface ICar
    {
        void Start();
    }

    public class SixSeaterCar : ICar
    {
        public void Start() { Console.WriteLine("SixSeaterCar is started."); }
    }
    public class FourSeaterCar : ICar
    {
        public void Start() { Console.WriteLine("FourSeaterCar is started."); }
    }

    public class CarFactory
    {
        public ICar GetCar(string carType)
        {
            switch(carType)
            {
                case "SixSeater":
                    return new SixSeaterCar();
                case "FourSeater":
                    return new FourSeaterCar();
            }
            return null;
        }
    }
    class program
    {
        static void Main(string[] args) {
            CarFactory carFactory = new CarFactory();
            ICar sixSeaterCar = carFactory.GetCar("SixSeater");
            ICar fourSeaterCar = carFactory.GetCar("FourSeater");
            fourSeaterCar.Start();
            sixSeaterCar.Start();
        }
    }
}
