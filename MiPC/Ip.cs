using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace MiPC
{
    class Ip
    {

        public Ip() { }

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
            Console.WriteLine("\t#\tInternet");
            Console.WriteLine("\t# ----------------------------------");
        }

        public void mostrar()
        {
            this.encabezado();

            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo["IPEnabled"].ToString() == "True")
                {
                    Console.WriteLine("\t{0}",mo["Caption"].ToString().Substring(11));
                    string[] ipaddresses = (string[]) mo["IPAddress"];
                    foreach (String ipad in ipaddresses)
                    {
                        Console.WriteLine("\t\tIpAddress: {0}", ipad);
                    }
                }
            }
            this.pausa();
        }
    }
}
