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
            try
            {
                if (args.Length > 0)
                {
                    ArrayList array = DataFileReader.LoadDataFile(args[0]);
                    double sdv = Stats.StdDev(array);
                    Console.WriteLine("Standard deviation of array = " + sdv);
                }
                else
                    throw new ArgumentException("Must have exactly 1 argument for file to be read.");
            }
            catch (FileNotFoundException fnfex)
            {
                Console.WriteLine(fnfex.Message + " - " + fnfex.FileName);
            }
            catch(ArgumentException aexc)
            {
                Console.WriteLine(aexc.Message);
            }
            catch(Exception exc)
            {
                Console.WriteLine("Stat program failed with the following error.");
                Console.WriteLine(exc.Message);
            }
        }
    }
}
