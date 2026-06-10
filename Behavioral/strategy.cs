using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Behavioral
{
    public class strategy
    {
        public void run()
            {
                PaymentContext context = new PaymentContext();
    
                context.SetPaymentStrategy(new CreditCardPayment());
                context.Pay(100);
    
                context.SetPaymentStrategy(new PayPalPayment());
                context.Pay(200);
    
                context.SetPaymentStrategy(new BitcoinPayment());
                context.Pay(300);
        }
    }

    //strategy interface
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    //concrete strategy 1
    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Credit Card.");
        }
    }

    //concrete strategy 2
    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using PayPal.");
        }
    }

    //concrete strategy 3
    public class BitcoinPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Bitcoin.");
        }
    }

    //context class
    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;
        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }
        public void Pay(decimal amount)
        {
            if (_paymentStrategy == null)
            {
                Console.WriteLine("Please select a payment method.");
                return;
            }
            _paymentStrategy.Pay(amount);
        }
    }

}
