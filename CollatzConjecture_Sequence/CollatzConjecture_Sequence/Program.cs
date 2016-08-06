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
                if (args.Length > 0)
                    input = "n";
                else
                    input = readConsole(startMsg);
                switch (input.ToLower())
                {
                    case "n":
                        if (args.Length > 0)
                        {
                            //pass the argument to the function
                            calculateCollatz(args[0]);
                            //prep the input so it will quit the application after running via command line args
                            input = "q";
                        }
                        else
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

        private static void calculateCollatz(string arg = "")
        {
            ulong gens = 0, high = 0;
            string input = (arg != String.Empty) ? arg : readConsole("Please enter a positive integer(whole number):");
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
                    //start calculating the collatz number for each number up till the ulong maximum
                    //until a result in generations matches the targetGen
                    Console.WriteLine("Calculating... This may take a while.");
                    ulong result = 0;
                    if(bruteForceFindGen(targetGen, out result))
                    {
                        Console.WriteLine("The number " + result + " takes " + targetGen + " generations to reach 1.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find a number that matches " + targetGen + " generations.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("ERROR - Invalid input.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("ERROR - Invalid input.");
                Console.ReadLine();
            }
        }

        private static bool bruteForceFindGen(ulong target, out ulong result)
        {
            ulong gen = 0;
            ulong high = 0;
            for(ulong i = 2; i < UInt64.MaxValue; i++)
            {
                gen = performCollatzConjecture(i, out high);
                if(gen == target)
                {
                    result = i;
                    return true;
                }
            }

            result = 0;
            return false;
        }
    }
}
