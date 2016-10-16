using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForm.Parsing
{
    class Calculator
    {
        public Calculator()
        {       
        }



        public string evaluate(string expression)
        {
            Parser calcParser = new Parser(expression);
            try
            {
                calcParser.parseExpression();
                return "" + calcParser.evaluate();
            }
            catch(Exception exc)
            {
                return exc.Message;
            }
        }
    }
}
