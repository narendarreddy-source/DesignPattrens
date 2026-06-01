using DesginPattrens;
using DesginPattrens.Creational;
using DesginPattrens.Structural;

namespace DesginPattrens
{
    public class Program
    {
        static void Main(string[] args)
        {
           Proxy proxy = new Proxy();
              proxy.Run();
            Console.WriteLine("Hello, World!");
        }
    }
}
