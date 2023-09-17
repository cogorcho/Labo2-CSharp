using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace MiPC
{
    class Nw
    {
        public Nw() { }

        private void pausa()
        {
            Console.Write(String.Format("\n\tPulse Enter: "));
            Console.ReadKey();
        }
        private void encabezado()
        {
            Console.Clear();
            Console.Write("\n\n");
            Console.WriteLine("\t# ----------------------------------");
            Console.WriteLine("\t#\tPlacas de Red");
            Console.WriteLine("\t# ----------------------------------");
        }

        public void mostrar()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            this.encabezado();
            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("\tNo network interfaces found.");
            }
            else
            {
                foreach (NetworkInterface adapter in nics)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    Console.WriteLine(String.Format("\t{0}",adapter.Description));
                    //Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                    Console.WriteLine("\t\tInterface type ..... : {0}", adapter.NetworkInterfaceType);
                    Console.WriteLine("\t\tPhysical Address ... : {0}", adapter.GetPhysicalAddress().ToString());
                    Console.WriteLine("\t\tOperational status . : {0}", adapter.OperationalStatus);
                }
            }
            this.pausa();
        }
    }
}
