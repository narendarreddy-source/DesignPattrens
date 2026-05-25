using DesginPattrens;
using DesginPattrens.Creational;

namespace Dsatest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Instance.Log("Application started");
            Console.WriteLine("Hello, World!");

            // Usage
            var emp1 = new DeepEmployee
            {
                Id = 1,
                Name = "John",
                Address = new Address { City = "Dallas", Country = "USA" }
            };

            var emp2 = emp1.Clone();
            emp2.Name = "Clone John";
            emp2.Address.City = "Austin";
        }
    }
}
