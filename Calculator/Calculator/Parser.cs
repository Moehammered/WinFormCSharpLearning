using System;

namespace Calculator
{
    /// <summary>
    /// Class to parse in the mathematical expression and convert it into an expression tree to be interpreted
    /// Source reading for idea: https://en.wikipedia.org/wiki/Parsing#Overview_of_process
    /// </summary>
    class Parser
    {
        private TokenGenerator tokenizer;
        private IExpression parsedExpression;

        public Parser(string source)
        {
            tokenizer = new TokenGenerator(source);
        }

        public void parseExpression()
        {
            //create the tokens
            tokenizer.createTokens();
            //displayTokenDebug();
            if(validateSyntax())
            {
                //build syntax/expression tree
                buildExpressionTree();
            }
            else
                throw new Exception("Invalid Input");
        }

        public int evaluate()
        {
            return parsedExpression.evaluate();
        }

        private bool validateSyntax()
        {
            bool expectingOperand = true;
            string[] tokens = tokenizer.Tokens;

            for(int i = 0; i < tokens.Length; i++)
            {
                bool isValid = expectingOperand ^ tokenizer.isOperator(tokens[i]);
                if(!isValid)
                    return false;
                expectingOperand = !expectingOperand;
            }

            return !expectingOperand; //Returns true only if we aren't expecting an operand still
        }

        private void buildExpressionTree()
        {
            parsedExpression = readLeft(tokenizer.Tokens.Length-2);
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
                string leftToken = tokenizer.Tokens[startPoint + 1];
                found = new Number(parseNumber(leftToken));
            }

            return found;
        }

        private IExpression parseLeftExpressions(int position)
        {
            IExpression found = null;
            IExpression left = null;
            IExpression right = null;

            string currToken = tokenizer.Tokens[position];
            string rightToken = tokenizer.Tokens[position + 1];
            Operation type = getOperationType(currToken);
            switch (type)
            {
                case Operation.ADDITION:
                case Operation.SUBTRACTION:
                    //grab the operand on the right, and parse the next operation to the left
                    right = new Number(parseNumber(rightToken));
                    left = readLeft(position - 2);
                    found = new Operator(left, right, type);
                    break;
                case Operation.MULTIPLICATION:
                case Operation.DIVISION:
                case Operation.MODULUS:
                    found = parseRightExpressions(position);
                    break;
                default: //this should not happen (since syntax validation would catch this earlier), but it is there to be safe
                    throw new Exception("Invalid Input. Found '" + currToken + "' when expecting operator.");
            }

            return found;
        }

        private IExpression readRight(int startPoint)
        {
            IExpression found = null;
            IExpression left = null;
            IExpression right = null;

            string currToken = "";
            if (startPoint < tokenizer.Tokens.Length)
                currToken = tokenizer.Tokens[startPoint];
            else
                currToken = tokenizer.Tokens[startPoint-1];

            Operation type = getOperationType(currToken);
            switch(type)
            {
                case Operation.MULTIPLICATION:
                case Operation.DIVISION:
                case Operation.MODULUS:
                    string leftToken = tokenizer.Tokens[startPoint - 1];
                    left = new Number(parseNumber(leftToken));
                    right = readRight(startPoint + 2);
                    found = new Operator(left, right, type);
                    break;
                default:
                    string rightToken = tokenizer.Tokens[startPoint - 1];
                    found = new Number(parseNumber(rightToken));
                    break;
            }

            return found;
        }

        private IExpression parseRightExpressions(int position)
        {
            IExpression found = null;
            IExpression left = null;
            IExpression right = null;
            
            //we need to find the next plus or minus operator
            int nextAorS = findNextPlusMinus(position);
            //and make this multiply/divide operations the right hand operand of them
            right = readRight(nextAorS + 2);
            //did we find a plus or minus operator when moving on to the left of the expression?
            if (nextAorS > 0)
            {
                //read on past the found operator, making any other operators to the left
                //it's left hand operand
                left = readLeft(nextAorS - 2);
                //build the current operand that has the multiplications to it's right as a single operand
                string currToken = tokenizer.Tokens[nextAorS];
                Operation type = getOperationType(currToken);
                found = new Operator(left, right, type);
            }
            else
                found = right;

            return found;
        }

        private int findNextPlusMinus(int startPosition)
        {
            while (startPosition > 0)
            {
                string CLT = tokenizer.Tokens[startPosition];
                if (CLT == "+" || CLT == "-")
                    break;
                startPosition -= 2;
            }

            return startPosition;
        }

        private Operation getOperationType(string token)
        {
            switch(token)
            {
                case "+":
                    return Operation.ADDITION;
                case "-":
                    return Operation.SUBTRACTION;
                case "*":
                    return Operation.MULTIPLICATION;
                case "/":
                    return Operation.DIVISION;
                case "%":
                    return Operation.MODULUS;
                default:
                    return Operation.NONE;
            }
        }

        private int parseNumber(string token)
        {
            int value = -1;
            if (!Int32.TryParse(token, out value))
                throw new Exception("Invalid Input. Failed to parse: " + token);

            return value;
        }

        private void displayTokenDebug()
        {
            Console.WriteLine("Tokens Generated");
            foreach (string token in tokenizer.Tokens)
            {
                Console.Write("[" + token + "]");
            }
            Console.WriteLine();
        }
    }
}
