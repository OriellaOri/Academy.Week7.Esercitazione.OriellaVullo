using Academy.Week7.Esercitazione.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week7.Esercitazione.SelfHosting
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Avvio del WCF (self hosting)
            using (ServiceHost host = new ServiceHost(typeof(ClientService)))
            {
                host.Open();

                Console.WriteLine("=== WCF Running ===");
                Console.Write("Press any key to end ...");
                Console.ReadKey();
            }
        }
    }
}
