using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qlik.Sense.RestClient;

namespace BasicConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            var senseServerUrl = args.Any() ? args[0] : "https://my.server.url";
            var restClient = new RestClient(senseServerUrl);
            restClient.AsNtlmUserViaProxy(false);
            Console.WriteLine(restClient.Get("/qrs/about"));

            var appName = "Log Monitor.qvf";
            var data = File.ReadAllBytes(Path.Combine(@"C:\ProgramData\Qlik\Sense\Repository\DefaultApps", appName));
            restClient.UploadApp("New " + appName, data);
        }
    }
}
