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
          Interpreter obj = new Interpreter();
            obj.Run();
            Console.WriteLine("Hello, World!");
        }
    }
}
