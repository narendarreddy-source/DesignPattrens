using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Structural
{
    public class Composite
    {
        public Composite()
        {
            IEmployee employee1 = new Employee("Alice", "HR");
            IEmployee employee2 = new Employee("Bob", "IT");
            IEmployee employee3 = new Employee("Charlie", "Finance");

            Manager manager = new Manager("David", "Management");

            manager.AddSubordinate(employee1);
            manager.AddSubordinate(employee2);
            manager.AddSubordinate(employee3);

            manager.GetDetails(1);


            Manager ceo = new Manager("Eve", "Executive");
            ceo.AddSubordinate(manager);
            ceo.GetDetails(0);
        }
    }

    public interface IEmployee
    {
        void GetDetails(int indentation);
    }

    public class Employee : IEmployee
    {
        private string _name;
        private string _department;
        public Employee(string name, string department)
        {
            _name = name;
            _department = department;
        }
        public void GetDetails(int indentation)
        {
            Console.WriteLine($"{new string(' ', indentation)}- {_name} ({_department})--> Leaf");
        }
    }

   public class Manager : IEmployee
    {
        private string _name;
        private string _department;
        private List<IEmployee> _subordinates = new List<IEmployee>();
        public Manager(string name, string department)
        {
            _name = name;
            _department = department;
        }
        public void AddSubordinate(IEmployee employee)
        {
            _subordinates.Add(employee);
        }
        public void GetDetails(int indentation)
        {
            Console.WriteLine($"{new string(' ', indentation)}+ {_name} ({_department})-->Composite");
            foreach (var subordinate in _subordinates)
            {
                subordinate.GetDetails(indentation + 2);
            }
        }
    }
}
