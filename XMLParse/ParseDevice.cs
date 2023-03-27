using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParse
{
    public class ParseDevice
    {
        public static Device ParseDevicee(string path)
        {
            string jsonString = File.ReadAllText(path);
            Device device = JsonConvert.DeserializeObject<Device>(jsonString);
            return device;
        }
    }
}
