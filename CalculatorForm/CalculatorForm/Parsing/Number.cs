namespace CalculatorForm.Parsing
{
    class Number : IExpression
    {
        private double value;
        
        public Number(double value)
        {
            this.value = value;
        }

        public double evaluate()
        {
            return value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}