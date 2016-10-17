using System;

namespace CalculatorForm.Parsing
{
    /// <summary>
    /// Responsible for the construction of the arithmetic expression.
    /// It takes in the tokens of an expression and converts them into a tree.
    /// The tokens are read from right to left, so that the left most side of the expression is
    /// in the leaf of the tree, and the right most in the root of the tree. This allows the
    /// expression to be evaluated from left to right.
    /// </summary>
    class ExpressionBuilder
    {
        private string[] expressionTokens;
        private IExpression expressionTree;
        private const int OPERAND_OFFSET = 1, OPERATOR_OFFSET = 2;

        public ExpressionBuilder(string[] tokens)
        {
            expressionTokens = tokens;
        }

        public IExpression ExpressionTree
        {
            get
            {
                if(expressionTree == null)
                {
                    expressionTree = readLeft(expressionTokens.Length - OPERATOR_OFFSET);
                }
                return expressionTree;
            }
        }

        private IExpression readLeft(int startPoint)
        {
            IExpression found = null;
            //if we haven't hit the end yet, look for more operators
            if (startPoint > 0)
                found = parseLeftExpressions(startPoint);
            else
            {
                //we've hit the end, so just get the operand
                string leftToken = expressionTokens[startPoint + OPERAND_OFFSET];
                found = new Number(parseNumber(leftToken));
            }

            return found;
        }

        private IExpression parseLeftExpressions(int position)
        {
            IExpression found = null;
            IExpression left = null;
            IExpression right = null;

            string currToken = expressionTokens[position];
            string rightToken = expressionTokens[position + OPERAND_OFFSET];
            Operation type = getOperationType(currToken);
            switch (type)
            {
                case Operation.ADDITION:
                case Operation.SUBTRACTION:
                    //grab the operand on the right, and parse the next operation to the left
                    right = new Number(parseNumber(rightToken));
                    left = readLeft(position - OPERATOR_OFFSET);
                    found = new Operator(left, right, type);
                    break;
                case Operation.MULTIPLICATION:
                case Operation.DIVISION:
                case Operation.MODULUS:
                case Operation.EXPONENT:
                    found = readAhead(position);
                    break;
                default: 
                    //validateSyntax should've caught this already, here to be safe
                    throw new Exception("Invalid Input. Found '" + currToken + 
                        "', expected operator.");
            }

            return found;
        }

        private IExpression readAhead(int position)
        {
            IExpression found = null;
            IExpression left = null;
            IExpression right = null;

            int nextPosition = findNextPlusMinus(position);
            //find all multiply, divide, modulus, and exponent operations
            right = parsePriorityExpressions(position);
            //did we find a plus or minus operator when reading ahead of the expression?
            if (nextPosition > 0)
            {
                //read on past the found operator, finding it's left operands
                left = readLeft(nextPosition - OPERATOR_OFFSET);
                //build the add or subtract operation we found at nextPosition
                string currToken = expressionTokens[nextPosition];
                Operation type = getOperationType(currToken);
                found = new Operator(left, right, type);
            }
            else //Return all the multiply and divide operations only
                found = right;

            return found;
        }
        
        private IExpression parsePriorityExpressions(int startPoint)
        {
            IExpression found = null;
            IExpression left = null;
            IExpression right = null;

            string currToken = "";
            if (startPoint > 0)
                currToken = expressionTokens[startPoint];

            Operation type = getOperationType(currToken);
            switch (type)
            {
                case Operation.MULTIPLICATION:
                case Operation.DIVISION:
                case Operation.MODULUS:
                    string rightToken = expressionTokens[startPoint + OPERAND_OFFSET];
                    right = new Number(parseNumber(rightToken));
                    left = parsePriorityExpressions(startPoint - OPERATOR_OFFSET);
                    found = new Operator(left, right, type);
                    break;
                case Operation.EXPONENT:
                    found = readHighestPrecedence(startPoint);
                    break;
                default:
                    string leftToken = expressionTokens[startPoint + OPERAND_OFFSET];
                    found = new Number(parseNumber(leftToken));
                    break;
            }

            return found;
        }

        private IExpression readHighestPrecedence(int startPosition)
        {
            IExpression right = null, left = null, found = null;

            int nextOP = findNextNonExponent(startPosition);
            string rightToken = expressionTokens[startPosition + OPERAND_OFFSET];

            right = parseExponent(startPosition);
            if (nextOP > 0)
            {
                Operation type = getOperationType(expressionTokens[nextOP]);
                switch (type)
                {
                    case Operation.MULTIPLICATION:
                    case Operation.DIVISION:
                    case Operation.MODULUS:
                        //parsePriorityExpression towards left side of this operator
                        left = parsePriorityExpressions(nextOP - OPERATOR_OFFSET);
                        found = new Operator(left, right, type);
                        //build operator here
                        break;
                    default:
                        found = right;
                        break;
                }
                //we steal the left operand and continue execution
            }
            else
                return right;

            return found;
        }

        private IExpression parseExponent(int startPosition)
        {
            IExpression left = null;
            IExpression right = null;
            IExpression found = null;

            string currToken = "";
            string rightToken = "";
            if (startPosition > 0)
                currToken = expressionTokens[startPosition];

            rightToken = expressionTokens[startPosition + OPERAND_OFFSET];
            Operation type = getOperationType(currToken);

            switch(type)
            {
                /*case Operation.ADDITION:
                case Operation.SUBTRACTION:
                    //just want to steal the right operand from the addition
                    break;*/
                case Operation.MULTIPLICATION:
                case Operation.DIVISION:
                case Operation.MODULUS:
                    //steal the right operand from the multiplication
                    found = new Number(parseNumber(rightToken));
                    //construct the operator and continue execution to the left of the found operator
                    break;
                case Operation.EXPONENT:
                    //take the right operand, parse exponent to the left
                    /*rightToken = expressionTokens[startPosition + OPERAND_OFFSET];*/
                    right = new Number(parseNumber(rightToken));
                    left = parseExponent(startPosition - OPERATOR_OFFSET);
                    found = new Operator(left, right, type);
                    break;
                default:
                    //hit a number
                    /*rightToken = expressionTokens[startPosition + OPERAND_OFFSET];*/
                    found = new Number(parseNumber(rightToken));
                    break;
            }

            return found;
        }

        private int findNextPlusMinus(int startPosition)
        {
            while (startPosition > 0)
            {
                string CLT = expressionTokens[startPosition];
                if (CLT == "+" || CLT == "-")
                    break;
                startPosition -= 2;
            }

            return startPosition;
        }

        private int findNextNonExponent(int startPosition)
        {
            while (startPosition > 0)
            {
                string CLT = expressionTokens[startPosition];
                if (CLT != "^")
                    break;
                startPosition -= 2;
            }

            return startPosition;
        }

        private Operation getOperationType(string token)
        {
            switch (token)
            {
                case "+":
                    return Operation.ADDITION;
                case "-":
                    return Operation.SUBTRACTION;
                case "x":
                case "*":
                    return Operation.MULTIPLICATION;
                case "/":
                    return Operation.DIVISION;
                case "%":
                    return Operation.MODULUS;
                case "^":
                    return Operation.EXPONENT;
                default:
                    return Operation.NONE;
            }
        }

        private double parseNumber(string token)
        {
            double value = -1;
            if (!Double.TryParse(token, out value))
                throw new Exception("Invalid Input. Failed to parse: " + token);

            return value;
        }
    }
}