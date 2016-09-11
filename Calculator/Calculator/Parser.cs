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
            }
            else
                throw new Exception("Invalid Input");
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
