using System;

namespace CalculatorForm.Parsing
{
    public enum Operation
    {
        NONE,
        ADDITION,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION,
        MODULUS,
        EXPONENT
    }

    /// <summary>
    /// An Operator class designed to evaluate arithmetic expressions.
    /// It does so by evaluting both of it's operand expressions before evaluting itself.
    /// The operations are checked for operation errors/exceptions.
    /// Information for this was found at: https://msdn.microsoft.com/en-us/library/74b4xzyw.aspx
    /// </summary>
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

        public double evaluate()
        {
            double result = 0;
            try
            {
                checked
                {
                    switch (op)
                    {
                        case Operation.ADDITION:
                            result = left.evaluate() + right.evaluate();
                            break;
                        case Operation.SUBTRACTION:
                            result = left.evaluate() - right.evaluate();
                            break;
                        case Operation.MULTIPLICATION:
                            result = left.evaluate() * right.evaluate();
                            break;
                        case Operation.DIVISION:
                            result = left.evaluate() / right.evaluate();
                            break;
                        case Operation.MODULUS:
                            result = left.evaluate() % right.evaluate();
                            break;
                        case Operation.EXPONENT:
                            result = Math.Pow(left.evaluate(), right.evaluate());
                            break;
                        default:
                            throw new Exception("No operator found for operation.");
                    }
                }
            }
            catch (DivideByZeroException divExc)
            {
                throw new DivideByZeroException("Divide by zero", divExc);
            }
            catch(OverflowException ofExc)
            {
                throw new OverflowException("Out of Range", ofExc);
            }

            return result;
        }

        public override string ToString()
        {
            string disp = "(" + left + " " + op + " " + right + ")";
            return disp;
        }
    }
}