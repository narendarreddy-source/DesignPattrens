using DesginPattrens;
using DesginPattrens.Behavioral;
using DesginPattrens.Creational;
using DesginPattrens.Structural;

namespace DesginPattrens
{
    public class Program
    {
        static void Main(string[] args)
        {
          Memento obj = new Memento();
            obj.Run();
            Console.WriteLine("Hello, World!");
        }
    }
}
