using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            displayTokenDebug();
            //validate syntax
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
            parsedExpression = readExpressions(tokenizer.Tokens.Length-2);
        }

        private IExpression readExpressions(int startPoint)
        {
            IExpression found = null;
            
            if (startPoint > 0)
            {
                //we haven't hit the end yet
                string currToken = tokenizer.Tokens[startPoint];
                string rightToken = tokenizer.Tokens[startPoint + 1];
                Operation type = getOperationType(currToken);
                Number right = new Number(parseNumber(rightToken));
                found = new Operator(readExpressions(startPoint - 2), right, type);
                Console.WriteLine("Found at: " + startPoint);
                Console.WriteLine(found);
            }
            else
            {
                //we've hit the end, so just get the operand
                string leftToken = tokenizer.Tokens[startPoint + 1];
                found = new Number(parseNumber(leftToken));
                Console.WriteLine("Found at: " + (startPoint+1));
                Console.WriteLine(found);
            }

            return found;
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
                default:
                    return Operation.NONE;
            }
        }

        private int parseNumber(string token)
        {
            int value = -1;

            if (!Int32.TryParse(token, out value))
                throw new Exception("Failed to parse: " + token);

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
