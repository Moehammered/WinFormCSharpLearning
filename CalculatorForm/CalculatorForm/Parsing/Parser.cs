using System;

namespace CalculatorForm.Parsing
{
    /// <summary>
    /// Class to parse in the mathematical expression and convert it into an expression tree to be interpreted
    /// Source reading for idea: https://en.wikipedia.org/wiki/Parsing#Overview_of_process
    /// </summary>
    class Parser
    {
        private TokenGenerator tokenizer;
        private ExpressionBuilder expressionBuilder;
        private IExpression parsedExpression;

        public Parser(string source)
        {
            tokenizer = new TokenGenerator(source);
        }

        public void parseExpression()
        {
            tokenizer.createTokens();
            if(validateSyntax())
            {
                expressionBuilder = new ExpressionBuilder(tokenizer.Tokens);
                parsedExpression = expressionBuilder.ExpressionTree;
                Console.WriteLine(parsedExpression);
            }
            else
                throw new Exception("Invalid Input.");
        }

        public double evaluate()
        {
            return parsedExpression.evaluate();
        }

        private bool validateSyntax()
        {
            bool expectingOperand = true;
            string[] tokens = tokenizer.Tokens;

            for(int i = 0; i < tokens.Length; i++)
            {
                //Only valid if they are exclusive of each other
                bool isValid = expectingOperand ^ tokenizer.isOperator(tokens[i]);
                if(!isValid)
                    return false;
                expectingOperand = !expectingOperand;
            }
            //Returns true only if we aren't expecting an operand still
            return !expectingOperand; 
        }
    }
}