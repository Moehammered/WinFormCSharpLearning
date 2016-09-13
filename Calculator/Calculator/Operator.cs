using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum Operation
    {
        NONE,
        ADDITION,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION
    }

    class Operator : IExpression
    {
        private IExpression left, right;
        private Operation op;

        public Operator(IExpression left, IExpression right, Operation op)
        {
            this.left = left;
            this.right = right;
            this.op = op;
        }

        public int evaluate()
        {
            switch(op)
            {
                case Operation.ADDITION:
                    return left.evaluate() + right.evaluate();
                case Operation.SUBTRACTION:
                    return left.evaluate() - right.evaluate();
                case Operation.MULTIPLICATION:
                    return left.evaluate() * right.evaluate();
                case Operation.DIVISION:
                    return left.evaluate() / right.evaluate();
                default:
                    return -1; //error somehow?
            }
        }

        public override string ToString()
        {
            string disp = "(" + left + " " + op + " " + right + ")";
            return disp;
        }
    }
}
