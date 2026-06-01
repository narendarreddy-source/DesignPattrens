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
          ChainOfResponsibility chainOfResponsibility = new ChainOfResponsibility();
              chainOfResponsibility.Run();
            Console.WriteLine("Hello, World!");
        }
    }
}
