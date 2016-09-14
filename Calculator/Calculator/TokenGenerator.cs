using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    /// <summary>
    /// This class will create expression tokens from original source string (e.g. 2+5*-3 -> [2][+][5][*][-3])
    /// No validation is handled in the syntax at this point, it simply creates a token for each piece of data
    /// The only exception is the very first token generated, the starting symbol is checked for validation
    /// Token separation is based on operator symbols and last known token
    /// </summary>
    class TokenGenerator
    {
        private string source;
        private string[] tokens;

        public string[] Tokens
        {
            get { return tokens; }
        }

        public TokenGenerator(string source)
        {
            this.source = source;
        }

        public void createTokens()
        {
            //filter through source string now
            List<string> foundTokens = new List<string>();
            int position = 0;

            if (isValidStart(source[position]))
            {
                while (position < source.Length)
                {
                    string token = "" + source[position];
                    position++; //move over to check next character

                    //Read the stream forward if we have stored an operator token previously 
                    //or if we've just started
                    if (foundTokens.Count > 0 && isOperator(foundTokens.Last()) ||
                        foundTokens.Count == 0)
                    {
                        readTrailingNumbers(ref position, ref token, ref source);
                    }

                    foundTokens.Add(token);
                }

                tokens = foundTokens.ToArray();
            }
            else
                throw new Exception("Invalid Input. Expected operand, found '" + source[position] + "'");
        }

        private void readTrailingNumbers(ref int position, ref string token, ref string source)
        {
            while (position < source.Length && isNumber(source[position]))
            {
                token += source[position];
                position++;
            }
        }

        private bool isValidStart(char c)
        {
            return (isNumber(c) || c == '+' || c == '-');
        }

        private bool isNumber(char character)
        {
            return (character >= '0' && character <= '9');
        }

        public bool isOperator(string token)
        {
            return (token == "+" || token == "-"
                || token == "*" || token == "/" || token == "%");
        }
    }
}
