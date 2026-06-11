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
            Template obj = new Template();
            obj.run();
            Console.WriteLine("Hello, World!");
        }
    }
}
