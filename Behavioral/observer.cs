using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Behavioral
{
    public class observer
    {
        public void Run()
        {
            var stock = new Stock("MSFT", 150.00m);
            var investor1 = new Investor("Alice");
            var investor2 = new Investor("Bob");
            stock.Attach(investor1);
            stock.Attach(investor2);
            stock.SetPrice(155.00m);
            stock.Detach(investor1);
            stock.SetPrice(160.00m);
        }

        //observer
        public interface IInvestor
        {
            void Update(string message);
        }

        //concrete observer
        public class Investor : IInvestor
        {
            public string Name { get; }
            public Investor(string name)
            {
                Name = name;
            }
            public void Update(string message)
            {
                Console.WriteLine($"{Name} received update: {message}");
            }
        }

        //subject
        public class Stock
        {
            private readonly List<IInvestor> _investors = new List<IInvestor>();
            public string Symbol { get; }
            public decimal Price { get; private set; }
            public Stock(string symbol, decimal price)
            {
                Symbol = symbol;
                Price = price;
            }
            public void Attach(IInvestor investor)
            {
                _investors.Add(investor);
            }
            public void Detach(IInvestor investor)
            {
                _investors.Remove(investor);
            }
            public void Notify()
            {
                foreach (var investor in _investors)
                {
                    investor.Update($"{Symbol} price changed to {Price}");
                }
            }
            public void SetPrice(decimal price)
            {
                Price = price;
                Notify();
            }
        }

    }
}
