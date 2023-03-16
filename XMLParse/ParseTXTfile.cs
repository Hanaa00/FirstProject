using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParse
{
    public class ParseTXTfile
    {
        public static string Parse(string path)
        {
            List<IP> ipList = new List<IP>();
            bool isIpListSection = false;
            using (StreamReader streamReader = new StreamReader(path))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.StartsWith("---------------"))
                    {
                        isIpListSection = true;
                        continue;
                    }
                    if (isIpListSection && !line.StartsWith("---------------"))
                    {
                        string[] fields = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (fields.Length >= 6)
                        {
                            IP ip = new IP();
                            ip.IPAddress = fields[0];
                            ip.NIC = fields[1];
                            ip.Status = fields[2];
                            ip.Type = fields[3];
                            ip.Array = fields[4];
                            ip.Controller = fields[5];
                            ipList.Add(ip);
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("IP Address\tNIC\tStatus\tType\tArray\tController");
            foreach (IP ip in ipList)
            {
                sb.AppendLine($"{ip.IPAddress}\t{ip.NIC}\t{ip.Status}\t{ip.Type}\t{ip.Array}\t{ip.Controller}");
            }

            return sb.ToString();
        }
    }

}
