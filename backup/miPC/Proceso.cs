using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.ComponentModel;

namespace MiPC
{
    class Proceso
    {
        public Proceso() { }

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
            Console.WriteLine("\t#\tProcesos");
            Console.WriteLine("\t# ----------------------------------");
        }

        public void mostrar()
        {
            this.encabezado();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_Process");
            foreach (ManagementObject obj in searcher.Get())
            {
                Console.WriteLine("\t\t{0}: {1} ({2})", 
                    obj["ProcessId"], obj["Caption"], obj["ExecutionState"]);

                //Detalles
                /*
                foreach (PropertyData item in obj.Properties)
                {
                    Console.WriteLine("\t\t{0}: {1} (Tipo: {2})", item.Name, item.Value, item.GetType());
                }
                Console.WriteLine("\t ----------------------------------");
                */
            }
            pausa();
        }
    }
}
