using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if(args.Length == 1)
                {
                    Parser calcParser = new Parser(args[0]);
                    calcParser.parseExpression();
                    Console.WriteLine("Result: " + calcParser.evaluate());
                }
                else
                {
                    throw new ArgumentException("Invalid Input. Wrong number of arguments.");
                }
            }
            catch(ArgumentException argExc)
            {
                Console.WriteLine(argExc.Message);
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}