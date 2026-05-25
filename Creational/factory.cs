using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Creational
{
    public class factory
    {
    }
    public interface INotification
    {
        public void Notify(string Message);
    }
    public class EmailNotification : INotification
    {
        public void Notify(string Message)
        {
            Console.WriteLine($"Email:--> {Message}");
        }
    }
    public class SmsNotification : INotification
    {
        public void Notify(string Message)
        {
            Console.WriteLine($"Sms:--> {Message}");
        }
    }
    public interface INoitifactionFactory
    {
        public INotification CreateNotification();
    }
    public class EmailFactory : INoitifactionFactory {
        public INotification CreateNotification() => new EmailNotification();
    }
    public class SmsFactory : INoitifactionFactory
    {
        public INotification CreateNotification() => new SmsNotification();
    }
}
