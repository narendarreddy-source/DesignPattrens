using DesginPattrens;
using DesginPattrens.Creational;
using DesginPattrens.Structural;

namespace Dsatest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stripe = new StripePaymentGateway();
            var paypal = new PaypalPaymentGateway();
            var razorpay = new RazorpayPaymentGateway();

            PaymentMethod creditcard = new CreditCardPayment(stripe);
            creditcard.MakePayment(100);

            PaymentMethod UpiPayment = new UpiPayment(paypal);
            UpiPayment.MakePayment(200);

            PaymentMethod ACHPayment = new ACHPayment(razorpay);
            ACHPayment.MakePayment(300);

            var composite = new Composite();


        }
    }
}
