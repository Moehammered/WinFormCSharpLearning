using System;
using System.Text;
using System.IO;
using System.Collections;

namespace Stat
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                ArrayList array = DataFileReader.LoadDataFile(args[0]);
                if (array.Count != 0)
                {
                    double sdv = Stats.StdDev(array);
                    Console.WriteLine("Standard deviation of array = " + sdv);
                }
                else
                    Console.WriteLine("Invalid data set given. No data found.");
            }
            else
                Console.WriteLine("No arguments found. Please give a file path to a data set of numbers.");
        }
    }
}
