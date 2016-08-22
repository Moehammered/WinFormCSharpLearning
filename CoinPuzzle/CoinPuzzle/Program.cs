using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoinPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            CoinRow cr = new CoinRow();

            // set up coin puzzle
            cr.PrintCoin();
            cr.ScrambleRow();
            cr.PrintCoin();
            PrintMenu();

            // run coin puzzle
            string input;
            while (!cr.AllHeadsUp())
            {
                input = Console.ReadLine();

                if (input == "1") cr.Operation1();
                else if (input == "2") cr.Operation2();
                else if (input == "3") cr.Operation3();
                else if (input == "x") return;
                else if (input == "h") PrintMenu();
                else
                {
                    Console.WriteLine("ERROR - Invalid Command");
                    PrintMenu();
                }
                cr.PrintCoin();
            }

            // finish up coin puzzle
            Console.WriteLine("CONGRATULATIONS, You have solved the Coin puzzle");
            Console.ReadLine();
        }

        /// <summary>
        /// Print the menu of commands for this program
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine("Coin Puzzle Menu");
            Console.WriteLine("1 - Flip coins 1, 2, & 5");
            Console.WriteLine("2 - If coin 1 is heads, flip 2 & 3, else flip 3 & 4");
            Console.WriteLine("3 - Swap coins 1 & 4");
            Console.WriteLine("x - Exit the program");
            Console.WriteLine("h - Print this help menu");
            Console.WriteLine();
        }
    }
}
