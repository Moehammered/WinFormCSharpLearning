namespace CalculatorForm.Parsing
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