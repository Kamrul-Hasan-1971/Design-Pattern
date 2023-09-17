using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Factory_Method
{
    // Provides an abstract class or interface for creating factory and using that factory request for object instead of directly creating it.
    // Solve problem while creating objects
    // Delegate the creation of object to subclass
    // The subclass is responsible for creating object
    public interface IVehicle
    {
        public void Manufacture();
    }

    public class TataCar : IVehicle
    {
        public void Manufacture() { Console.WriteLine("Manufactured Tata car."); }
    }

    public class TataBike : IVehicle
    {
        public void Manufacture() { Console.WriteLine("Manufactured Tata bike."); }
    }

    public class TeslaCar : IVehicle
    {
        public void Manufacture() { Console.WriteLine("Manufactured Tesla car."); }
    }

    public class TeslaBike : IVehicle
    {
        public void Manufacture() { Console.WriteLine("Manufactured Tesla bike."); }
    }

    public abstract class CarCompany
    {
        public IVehicle ProduceVehicle(string vehicleType)
        {
            IVehicle vehicle = ManufactureVehicle(vehicleType);
            vehicle.Manufacture();
            return vehicle;
        }

        protected abstract IVehicle ManufactureVehicle(string vehicleType);
    }

    public class TeslaCompany: CarCompany
    {
        protected override IVehicle ManufactureVehicle(string vehicleType)
        {
            if(vehicleType == "Car")
            {
                return new TeslaCar();
            }
            else
            {
                return new TeslaBike();
            }
        }
    }

    public class TataCompany : CarCompany
    {
        protected override IVehicle ManufactureVehicle(string vehicleType)
        {
            if (vehicleType == "Car")
            {
                return new TataCar();
            }
            else
            {
                return new TataBike();
            }
        }
    }
    class program
    {
        static void main(string[] args)
        {
            CarCompany teslaCompany = new TeslaCompany();
            IVehicle teslaCar = teslaCompany.ProduceVehicle("Car");
            IVehicle teslaBike = teslaCompany.ProduceVehicle("Bike");

            CarCompany tataCompany = new TataCompany();
            IVehicle tataCar = tataCompany.ProduceVehicle("Car");
            IVehicle tataBike = tataCompany.ProduceVehicle("Bike");
        }
    }
}
