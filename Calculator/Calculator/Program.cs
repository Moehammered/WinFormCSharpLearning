using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Console.WriteLine("Arg 0: " + args[0]);
                    List<string> pieces = findExpressions(args[0]);
                    Console.WriteLine("Pieces found.");
                    foreach(string p in pieces)
                    {
                        Console.Write("[" + p + "]");
                    }
                    Console.WriteLine();
                    Console.WriteLine(evaluateExpression(pieces));
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

        static void evaluateMultDiv(ref List<string> expressions)
        {
            for(int i = 1; i < expressions.Count; i+=2)
            {
                Number left, right;
                left = new Number(Int32.Parse(expressions[i - 1]));
                right = new Number(Int32.Parse(expressions[i + 1]));
                if (expressions[i] == "*" || expressions[i] == "/")
                {
                    //evaluate it
                    Operator op = new Operator(left, right, stringOpToEnum(expressions[i]));
                    //convert it to string
                    string result = "" + op.evaluate();
                    //edit list
                    expressions[i - 1] = result;
                    expressions.RemoveRange(i, 2);
                    i -= 2; //move back a bit so loop can catch next operator
                }
            }
        }

        static int evaluateExpression(List<string> expressions)
        {
            evaluateMultDiv(ref expressions);
            int result = 0;
            Number left, right;
            right = new Number(Int32.Parse(expressions[0]));
            result = right.evaluate();
            expressions.RemoveAt(0);

            while(expressions.Count > 0)
            {
                Operation opEnum = stringOpToEnum(expressions[0]);
                left = new Number(result);
                right = new Number(Int32.Parse(expressions[1]));
                Operator op = new Operator(left, right, opEnum);
                result = op.evaluate();
                expressions.RemoveRange(0, 2);
            }

            return result;
        }

        static Operation stringOpToEnum(string op)
        {
            switch(op)
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
                    return Operation.ADDITION;
            }
        }

        static List<string> findExpressions(string statement)
        {
            List<string> exp = new List<string>();

            int index = 0;
            bool expectingOperand = true;

            while(index < statement.Length)
            {
                string piece = "";
                if(expectingOperand)
                {
                    //we need to find a number or a sign and a number, otherwise error
                    //check for signs
                    if (statement[index] == '+' || statement[index] == '-')
                    {
                        //we found a sign, so check if next on is a number, and if so, start gathering the numbers
                        if (statement[index + 1] != '+' && statement[index + 1] != '-' && statement[index + 1] != '*' && statement[index + 1] != '/')
                        {
                            piece += statement[index];
                            index++;
                        }
                        else //we found another sign, error
                        {
                            //error
                            throw new Exception("Expected operand. Found: '" + statement[index + 1] + "'");
                        }
                    }
                    else if (statement[index] < '0' || statement[index] > '9')
                        throw new Exception("Expected operand. Found: '" + statement[index] + "'");
                    //get all the numbers
                    while (index < statement.Length && statement[index] >= '0' && statement[index] <= '9')
                    {
                        piece += statement[index];
                        index++;
                    }
                    //we're done gathering it, flip modes and add it to exp list
                    expectingOperand = false;
                    exp.Add(piece);
                }
                else
                {
                    //we need to find an operator otherwise error
                    if (statement[index] == '+' || statement[index] == '-' || statement[index] == '*' || statement[index] == '/')
                    {
                        piece += statement[index];
                        index++;
                        exp.Add(piece);
                        expectingOperand = true;
                    }
                    else //we didn't find an operator, error
                    {
                        throw new Exception("Expected operator. Found: '" + statement[index] + "'");
                    }
                }
            }

            return exp;
        }
    }
}
