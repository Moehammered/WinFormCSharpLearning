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
            double sdv = Stdev(args[0]);
            Console.WriteLine("Standard deviation of array = " + sdv);
        }

        static double Stdev(string filepath)
        {
            ArrayList array = new ArrayList();
            string line;
            double value, total = 0, variance = 0, mean;

            // read the data from the file into array
            StreamReader fin = new StreamReader(filepath);
            while (!fin.EndOfStream)
            {
                line = fin.ReadLine();
                value = double.Parse(line);
                array.Add(value);
            }

            // calculate the mean of the data in array
            foreach (double x in array) total += x;
            mean = total / array.Count;
            Console.WriteLine("Mean: " + mean);
            // calculate the variance of array
            foreach (double x in array)
            {
                // complete code for variance
                variance += Math.Abs(mean - x);
            }
            variance /= (array.Count);

            // return the standard deviation
            return Math.Sqrt(variance);
        }
    }
}
