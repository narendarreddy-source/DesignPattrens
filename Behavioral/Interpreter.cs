using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Behavioral
{
    public class Interpreter
    {
        public void Run()
        {
            IExpression expression = new AddExpression(new NumberExpression(5), new NumberExpression(10));
            Console.WriteLine($"Result of interpreting the expression: {expression.Interpret()}");
        }
    }
    public class Context
    {
        public int Number { get; set; }
    }
    public interface IExpression
    {
        int Interpret();
    }

    // Terminal Expression
    public class NumberExpression : IExpression
    {
        private readonly int _number;
        public NumberExpression(int number)
        {
            _number = number;
        }
        public int Interpret()
        {
            return _number;
        }
    }

    // Non-Terminal Expression

    public class AddExpression : IExpression
    {
        private readonly IExpression _leftExpression;
        private readonly IExpression _rightExpression;  

        public AddExpression(IExpression leftExpression, IExpression rightExpression)
        {
            _leftExpression = leftExpression;
            _rightExpression = rightExpression;
        }
        public int Interpret()
        {
           return _leftExpression.Interpret() + _rightExpression.Interpret();
        }
    }
}
