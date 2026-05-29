using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Structural
{

    //Facade implemenation
    public class Facade : IOrderService
    {
        private readonly IPaymentService _payment;

        private readonly IInventoryService _inventory;

        private readonly IShippingService _shipping;

        private readonly INotificationService _notify;

        public Facade(IPaymentService payment, IInventoryService inventory,IShippingService shipping,INotificationService notify)

        {
            _payment = payment;

            _inventory = inventory;

            _shipping = shipping;

            _notify = notify;
        }
        public void PlaceOrder()

        {
            _payment.ProcessPayment();

            _inventory.CheckStock();

            _shipping.Ship();

            _notify.Notify();

        }
    }

    // Subsystem Interfaces

    public interface IPaymentService { void ProcessPayment(); }

    public interface IInventoryService { void CheckStock(); }

    public interface IShippingService { void Ship(); }

    public interface INotificationService { void Notify(); }



    // Subsystem Implementations

    public class PaymentService : IPaymentService
    {
        public void ProcessPayment() =>

            Console.WriteLine("Payment processed");
    }



    public class InventoryService : IInventoryService
    {
        public void CheckStock() =>

            Console.WriteLine(" Stock verified");
    }



    public class ShippingService : IShippingService
    {
        public void Ship() =>

            Console.WriteLine(" Shipment created");
    }



    public class NotificationService : INotificationService
    {
        public void Notify() =>

            Console.WriteLine("Customer notified");
    }



    // Facade Interface

    public interface IOrderService
    {
        void PlaceOrder();
    }
}
