// See https://aka.ms/new-console-template for more information
using Design_Pattern.Factory;
using Design_Pattern.Factory_Method;
using Design_Pattern.Iterator;
using Design_Pattern.Prototype;
using Design_Pattern.Singleton;


//iterator design pattern 

/*var collection = new WordsCollection();
collection.AddItem("a");
collection.AddItem("b");
collection.AddItem("c");

Console.WriteLine("Straight traversal:");
foreach (var element in collection)
{
    Console.WriteLine(element);
}

Console.WriteLine("Reverse traversal:");
collection.ReverseDirection();
foreach (var element in collection)
{
    Console.WriteLine(element);
}*/


//---------------------------------------------------------------------------------
//Singleton Pattern

/*Thread process1 = new Thread(() =>
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
}*/


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


//---------------------------------------------------------
//Factory pattern
/*CarFactory carFactory = new CarFactory();
ICar sixSeaterCar = carFactory.GetCar("SixSeater");
ICar fourSeaterCar = carFactory.GetCar("FourSeater");
fourSeaterCar.Start();
sixSeaterCar.Start();*/


//----------------------------------------------------------------
//Factory Method pattern

/*CarCompany teslaCompany = new TeslaCompany();
IVehicle teslaCar = teslaCompany.ProduceVehicle("Car");
IVehicle teslaBike = teslaCompany.ProduceVehicle("Bike");

CarCompany tataCompany = new TataCompany();
IVehicle tataCar = tataCompany.ProduceVehicle("Car");
IVehicle tataBike = tataCompany.ProduceVehicle("Bike");*/

//-----------------------------------------------------------------
// Prototype pattern

List<string> options = new List<string>() { "Sunroof", "Navigations", "Leather Seats" };
Car c1 = new Car("Ford", "Mustang", 2023, options);
Car c2 = c1.Clone() as Car;
c2.Options[0] = "Hasan";
c1.Options.ForEach(Console.WriteLine);
c2.Options.ForEach(Console.WriteLine);

