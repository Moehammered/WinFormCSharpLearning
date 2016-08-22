using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stat
{
    class DataFileReader
    {
        public static ArrayList LoadDataFile(string path)
        {
            ArrayList array = new ArrayList();
            string line;
            double value = 0;

            // read the data from the file into array
            try {
                StreamReader fin = new StreamReader(path);
                while (!fin.EndOfStream)
                {
                    line = fin.ReadLine();
                    if (double.TryParse(line, out value))
                        array.Add(value);
                }
            } catch (FileNotFoundException exc)
            {
                Console.WriteLine("Invalid file path or name given. File Not Found!");
            }

            return array;
        }
    }
}
