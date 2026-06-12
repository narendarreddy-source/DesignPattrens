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
            VisitorPattren obj = new VisitorPattren();
            obj.run();
            Console.WriteLine("Hello, World!");
        }
    }
}
