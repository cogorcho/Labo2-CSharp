using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace MiPC
{
    class Lpg
    {
        public Lpg() {

        }

        public void descripcion()
        {
            Console.WriteLine("\t *** Logical Program Group ***");
            Console.WriteLine("\tThe Win32_LogicalProgramGroup WMI class represents a program group");
            Console.WriteLine("\tin a computer system running Windows.");
            Console.WriteLine("\tFor example, Accessories or Startup.");
            pausa();
        }

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
            Console.WriteLine("\t#\tLogical Program Group");
            Console.WriteLine("\t# ----------------------------------");
        }

        public void mostrar()
        {
            this.encabezado();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalProgramGroup");

            foreach (ManagementObject obj in searcher.Get())
            {
                foreach (PropertyData item in obj.Properties)
                {
                    Console.WriteLine("\t{0}: {1}", item.Name, item.Value);
                }
                Console.WriteLine("\t ----------------------------------");
            }
            pausa();
        }
    }
}
