using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Prototype
{
    /*
    Definition:
        create new objects based on an existing object through cloning.
    Problem:
        1) Not all objects can be copied that way because some of the object’s fields may be private and not visible from outside of the object itself.
        2) Sometimes you only know the interface that the object follows, but not its concrete class, when, for example, a parameter in a method accepts 
           any objects that follow some interface.
    Pros: 
        1) By using the prototype pattern, we can avoid the costly process of creating a new object from scratch each time we 
        need one. Instead, we can create a prototype object and clone it as many times as we need new objects. An example 
        of the prototype pattern is the creation of a new object in JavaScript using the Object.create() method. The method 
        creates a new object with the same properties and methods as the prototype object.
        2) You can clone objects without coupling to their concrete classes.
        3) You can get rid of repeated initialization code in favor of cloning pre-built prototypes.
        4) You can produce complex objects more conveniently.
    Cons: 
        1) Cloning complex objects that have circular references might be very tricky.
    */
    public abstract class Prototype
    {
        public abstract Prototype Clone();
    }

    public class Car : Prototype
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public List<string> Options { get; set; }

        public Car(string make, string model, int year, List<string>options) 
        {
            Make = make;
            Model = model;
            Year = year;
            Options = options;
        }

        public override Prototype Clone()
        {
            return new Car(Make, Model, Year,new List<string>(Options));
        }
    }
    class program
    {
        static void main(string[] args)
        {
            List<string> options = new List<string>() { "Sunroof", "Navigations", "Leather Seats" };
            Car c1 = new Car("Ford", "Mustang", 2023, options);
            Car c2 = c1.Clone() as Car;
            c2.Options[0] = "Hasan";
            c1.Options.ForEach(Console.WriteLine);
            c2.Options.ForEach(Console.WriteLine);
        }
    }
}
