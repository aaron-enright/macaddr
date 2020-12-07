using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace macaddr
{
    class Program
    {
        static void Main(string[] args)
        {
            var macAddr = (
                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                ).FirstOrDefault();

            var formatArg = (args.Length == 0) ? "-f1" : args[0];

            string prettyMacAddr = "";

            switch (formatArg)
            {
                case "-f2":
                    prettyMacAddr = ($"{macAddr.Substring(0, 2)}-{macAddr.Substring(2, 2)}-{macAddr.Substring(4, 2)}-{macAddr.Substring(6, 2)}-{macAddr.Substring(8, 2)}-{macAddr.Substring(10, 2)}");
                    break;
                case "-f3":
                    prettyMacAddr = ($"{macAddr.Substring(0, 3)}.{macAddr.Substring(3, 3)}.{macAddr.Substring(6, 3)}.{macAddr.Substring(9, 3)}");
                    break;
                default:
                    prettyMacAddr = ($"{macAddr.Substring(0, 2)}:{macAddr.Substring(2, 2)}:{macAddr.Substring(4, 2)}:{macAddr.Substring(6, 2)}:{macAddr.Substring(8, 2)}:{macAddr.Substring(10, 2)}");
                    break;
            }

            Console.WriteLine($"MAC address: {prettyMacAddr}");
        }
    }
}
