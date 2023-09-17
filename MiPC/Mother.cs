using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.ComponentModel;

namespace MiPC
{
    class Mother
    {
        public Mother() { }

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
            Console.WriteLine("\t#\tPlaca Madre");
            Console.WriteLine("\t# ----------------------------------");
        }

        public void mostrar()
        {
            this.encabezado();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");

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

