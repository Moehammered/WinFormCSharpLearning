using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The collatz conjecture works like this:
/// -Take a positive integer greater than 1, and repeat these rules while the number is not equal to 1
/// ->if n is even, half it, otherwise
/// ->if n is odd, multiply it by 3, then add 1 to it
/// </summary>

namespace CollatzConjecture_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string startMsg = "Input 'n' to supply a number for Collatz Conjecture.\n";
            startMsg += "Input 'g' to find a number from Collatz Conjecture.\n";
            startMsg += "Input 'q' to quit application.";
            string input = "";
            while(input.ToLower() != "q")
            {
                input = readConsole(startMsg);
                switch (input.ToLower())
                {
                    case "n":
                        calculateCollatz();
                        break;
                    case "g":
                        //find number from generations
                        findCollatzNumber();
                        break;
                    case "q":
                        Console.WriteLine("Quitting application.");
                        break;
                    default:
                        Console.WriteLine("Invalid selection. '" + input + "' is not a known command.");
                        break;
                }
            }
            Console.WriteLine("Press ANY key to terminate...");
            Console.Read();
        }

        private static string readConsole(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }

        private static ulong parseNumber(string input)
        {
            ulong result = 0;
            if (!UInt64.TryParse(input, out result))
                return 0;
            return result;
        }

        private static bool isInputValid(string input)
        {
            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] < '0' || input[i] > '9')
                    return false;
            }

            return true;
        }

        private static bool isNumberValid(ulong number)
        {
            return number > 1;
        }

        private static ulong performCollatzConjecture(ulong number, out ulong highestValue)
        {
            ulong generations = 0;
            highestValue = number;
            while(number != 1)
            {
                if (number % 2 == 0)
                    number /= 2;
                else
                    number = number * 3 + 1;

                if(number <= 0)
                {
                    Console.WriteLine("Number flow error. Number has reached: " + number);
                    Console.ReadLine();
                    break;
                }

                highestValue = highestValue < number ? number : highestValue;
                generations++;
            }

            return generations;
        }

        private static void calculateCollatz()
        {
            ulong gens = 0, high = 0;
            string input = readConsole("Please enter a positive integer(whole number):");
            if (isInputValid(input))
            {
                ulong number = parseNumber(input);
                if (isNumberValid(number))
                {
                    gens = performCollatzConjecture(number, out high);
                    Console.WriteLine("The number " + number + " reduced to 1 in " + gens + " generations.");
                    Console.WriteLine("The highest number in the sequence was " + high);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("ERROR - Invalid Input");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("ERROR - Invalid Input");
                Console.ReadLine();
            }
        }

        private static void findCollatzNumber()
        {
            ulong targetGen = 0;
            string input = readConsole("Please enter a positive integer for desired generation count:");
            if(isInputValid(input))
            {
                targetGen = parseNumber(input);
                if(isNumberValid(targetGen))
                {

                }
            }
        }
    }
}
