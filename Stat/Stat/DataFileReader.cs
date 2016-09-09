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
                    else
                        throw new Exception("Invalid double in " + path);
                }
            } catch (FileNotFoundException exc)
            {
                throw new FileNotFoundException("Unable to find specified file", path);
            }

            return array;
        }
    }
}
