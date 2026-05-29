using DesginPattrens;
using DesginPattrens.Creational;
using DesginPattrens.Structural;

namespace Dsatest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Create subsystem objects
            IPaymentService payment = new PaymentService();
            IInventoryService inventory = new InventoryService();
            IShippingService shipping = new ShippingService();
            INotificationService notify = new NotificationService();

            // Create Facade
            IOrderService orderService = new Facade(payment, inventory, shipping, notify);

            // Call Facade method
            orderService.PlaceOrder();
        }
    }
}
