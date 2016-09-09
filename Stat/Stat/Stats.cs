using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stat
{
    class Stats
    {
        public static double Mean(ArrayList array)
        {
            if (array.Count == 0)
                throw new Exception("Must have at least 1 item to calculate mean.");
            double total = 0, mean = 0;
            // calculate the mean of the data in array
            foreach (double x in array) total += x;
            mean = total / array.Count;

            return mean;
        }

        public static double Variance(ArrayList array)
        {
            double mean = Mean(array);
            if (array.Count < 2)
                throw new Exception("Must have at least 2 items in order to calculate std dev");
            double variance = 0;

            // calculate the variance of array
            foreach (double x in array)
            {
                // complete code for variance
                variance += Math.Pow(x - mean, 2);
            }
            variance /= ((array.Count > 1) ? array.Count - 1 : 1);

            return variance;
        }

        public static double StdDev(ArrayList array)
        {
            return Math.Sqrt(Variance(array));
        }
    }
}
