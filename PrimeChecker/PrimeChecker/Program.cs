using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while (input.ToLower() != "q")
            {
                Console.WriteLine("\n[Main Selection]");
                input = readConsole("Input 'p' to check if a number is prime.\nInput 'q' to quit.");
                switch(input.ToLower())
                {
                    case "q":
                        Console.WriteLine("\nQuitting application. Press ANY key to continue...");
                        Console.Read();
                        break;
                    case "p":
                        Console.WriteLine("\n[Checking Prime Number]");
                        checkPrimeNumber();
                        break;
                    default:
                        Console.WriteLine("Input '" + input + "' is not a valid command.");
                        break;
                }
            }
        }

        private static string readConsole(string msg)
        {
            Console.WriteLine(msg);
            string input = Console.ReadLine();
            return input;
        }

        private static int parseNumber(string value)
        {
            int result = 0;
            
            //if the number fails to parse correctly
            if(!Int32.TryParse(value, out result))
                result = -1; //return a negative value
            
            return result;
        }

        private static bool isPrime(int number)
        {
            //any root of a number that contains a divisor, the divisor applies to it's squared value also.
            //Simple terms, if we check the root number (makes for less checking), the original number is checked too.
            int max = (int)Math.Sqrt(number);

            for(int i = 2; i <= max; i++)
            {
                //if any number that leads up to itself is evenly divisable, it is not prime
                if (number % i == 0)
                    return false;
            }
            //no division were found, so it is prime
            return true;
        }

        private static void checkPrimeNumber()
        {
            int number = -1;
            string input = "";
            //get input from user
            while (number < 0)
            {
                input = readConsole("Input a positive integer value.");
                number = parseNumber(input);
                if (number < 0)
                {
                    Console.WriteLine("Value is not a positive integer.");
                }
            }
            //now check for prime
            if (isPrime(number))
                Console.WriteLine("{0} is prime.", number);
            else
                Console.WriteLine("{0} isn't prime.", number);
            Console.WriteLine("Press ENTER key to continue...");
            Console.ReadLine();
        }
    }
}
