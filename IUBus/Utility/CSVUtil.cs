using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace IUBus.Utility
{
    public static class CSVUtil
    {
        public static List<string> ReadCSV(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath).ToList();
            }

            return null;
        }
    }
}
