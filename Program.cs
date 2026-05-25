using DesginPattrens;
using DesginPattrens.Creational;
using DesginPattrens.Structural;

namespace Dsatest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Instance.Log("Application started");
            Console.WriteLine("Hello, World!");

            // Usage
           ISmsService smsService = new SmsAdapter();
              smsService.Send("Hello from the Adapter pattern!");
    


        }
    }
}
