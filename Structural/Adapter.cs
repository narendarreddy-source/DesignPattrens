using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Structural
{
    public class Adapter
    {
    }

    //Existing Interface your system using currently
    public interface ISmsService
    {
        void Send(string message);
    }

    //New Interface you want to use like thrid party (incompatible)
    public class NewSmsProvider
    {
        public void PushMessage(string message)
        {
           Console.WriteLine($"Message sent using NewSmsProvider: {message}");
        }
    }

    //Adapter class to make NewSmsProvider compatible with ISmsService
    public class SmsAdapter : ISmsService
    {
        private readonly NewSmsProvider _newSmsProvider = new NewSmsProvider();
        public void Send(string message)
        {
            _newSmsProvider.PushMessage(message);
        }
    }
}
