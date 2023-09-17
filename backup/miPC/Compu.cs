using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace MiPC
{
    class Compu
    {

        public Compu() { }

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
            Console.WriteLine("\t#\tInformación de la Computadora");
            Console.WriteLine("\t# ----------------------------------");
        }

        public void mostrar()
        {
            this.encabezado();
            this.encabezado();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

            foreach (ManagementObject obj in searcher.Get())
            {
                foreach (PropertyData item in obj.Properties)
                {
                    Console.WriteLine("\t\t{0}: {1}", item.Name, item.Value);
                }
                Console.WriteLine("\t ----------------------------------");
            }
            pausa();
        }
    }
}
