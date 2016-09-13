using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Number : IExpression
    {
        private int value;
        
        public Number(int value)
        {
            this.value = value;
        }

        public int evaluate()
        {
            return value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
