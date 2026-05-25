using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Creational
{
    public class Prototype
    {
    }
    public class Address
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
    public interface IPrototype<T>
    {
        T Clone();
    }

    // SHALLOW COPY
    public class ShallowEmployee : IPrototype<ShallowEmployee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }   // Reference type

        public ShallowEmployee Clone()
        {
            return (ShallowEmployee)this.MemberwiseClone();
        }
    }

    // DEEP COPY
    public class DeepEmployee : IPrototype<DeepEmployee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public DeepEmployee Clone()
        {
            return new DeepEmployee
            {
                Id = this.Id,
                Name = this.Name,
                Address = new Address
                {
                    City = this.Address.City,
                    Country = this.Address.Country
                }
            };
        }
    }
}
