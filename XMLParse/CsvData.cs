using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParse
{
    public class CsvData
    {
        public int Module { get; set; }
        public string Label { get; set; }
        public double CMGSize { get; set; }
        public double CacheSize { get; set; }
        public double SMSize { get; set; }
        public double CacheResidencySize { get; set; }
    }
}
