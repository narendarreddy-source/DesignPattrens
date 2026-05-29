using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Structural
{
    public class Decorator
    {
        public Decorator() {
            INotifier notifier = new SMSDecorator(new EmailDecorator(new BasicNotifier()));
            notifier.Send("Decorator Pattren in Action");
        }
        
    }
    public interface INotifier
    {
        void Send(string message);
    }

    //Base component
    public class BasicNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine("Sending:" +message);
        }
    }

    //base decorator
    public abstract class NotifierDecorator : INotifier
    {
        protected readonly INotifier _notifier;
        protected NotifierDecorator(INotifier notifier)
        {
            _notifier = notifier;
        }

        public virtual void Send(string message)
        {
            _notifier.Send(message);
        }
    }

    public class EmailDecorator : NotifierDecorator
    {
        public EmailDecorator(INotifier notifier) : base(notifier) { }
        
        public override void Send(string messsage)
        {
            base.Send(messsage);
            Console.WriteLine("Email Sent:" +messsage);
        }
    }
    public class SMSDecorator : NotifierDecorator
    {
        public SMSDecorator(INotifier notifier) : base(notifier) { }

        public override void Send(string messsage)
        {
            base.Send(messsage);
            Console.WriteLine("SMS Sent:" + messsage);
        }
    }
}
