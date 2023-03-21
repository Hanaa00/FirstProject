using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParse
{
    public class ParseCSVfile
    {
        public static string Parse(string path)
        {
            List<Cache> cacheList = new List<Cache>();

            using (var parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Skip header row
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();
                    var module = fields[0] == "" ? " " : fields[0];
                    var label = fields[1] == "" ? " " : fields[1];
                    var cmgSize = fields[2] == "" ? " " : fields[2];
                    var cacheSize = fields[3] == "" ? " " : fields[3];
                    var smSize = fields[4] == "" ? " " : fields[4];
                    var residencySize = fields[5] == "" ? " " : fields[5];
                    var cache = new Cache(module, label, cmgSize, cacheSize, smSize, residencySize);
                    cacheList.Add(cache);
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (Cache cache in cacheList)
            {
                sb.AppendLine($"Module number: {cache.ModuleNumber}\r\n" +
                    $"Label: {cache.Label}\r\n" +
                    $"CMG size: {cache.CMGSize}\r\n" +
                    $"Cache size: {cache.CacheSize}\r\n" +
                    $"SM size: {cache.SMSize}\r\n" +
                    $"Cache Residency Size: {cache.CacheResidencySize}\r\n");
            }

            return sb.ToString();
        }
    }
}


