using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Structural
{
    public class Bridge
    {
    }

    /// <summary>
    ///implementor interface
    /// </summary>
    public interface IPaymentGateway
    {
        void ProcessPayment(decimal amount);
    }

    // concrete implementors
    public class StripePaymentGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} using Stripe.");
        }
    }

    public class PaypalPaymentGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} using PayPal.");
        }
    }
    
    public class RazorpayPaymentGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} using Razorpay.");
        }
    }


    //abstraction
    public abstract class PaymentMethod
    {
        protected IPaymentGateway _paymentGateway;
        public PaymentMethod(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;
        }
        public abstract void MakePayment(decimal amount);
    }


    // refined abstraction
    public class ACHPayment : PaymentMethod
    {
        public ACHPayment(IPaymentGateway paymentGateway) : base(paymentGateway)
        {
        }
        public override void MakePayment(decimal amount)
        {
            Console.WriteLine("Initiating online payment...");
            _paymentGateway.ProcessPayment(amount);
        }
    }

    public class CreditCardPayment : PaymentMethod
    {
        public CreditCardPayment(IPaymentGateway paymentGateway) : base(paymentGateway)
        {
        }
        public override void MakePayment(decimal amount)
        {
            Console.WriteLine("Initiating credit card payment...");
            _paymentGateway.ProcessPayment(amount);
        }
    }

    public class UpiPayment : PaymentMethod
    {
        public UpiPayment(IPaymentGateway paymentGateway) : base(paymentGateway)
        {
        }
        public override void MakePayment(decimal amount)
        {
            Console.WriteLine("Initiating UPI payment...");
            _paymentGateway.ProcessPayment(amount);
        }
    }
}
