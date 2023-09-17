using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace MiPC
{
    class Cpu
    {
        public Cpu() { }
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
            Console.WriteLine("\t#\tCPU");
            Console.WriteLine("\t# ----------------------------------");
        }

        public void mostrar()
        {
            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");
            this.encabezado();
            foreach (ManagementObject obj in myProcessorObject.Get())
            {
                Console.WriteLine("\tName  -  " + obj["Name"]);
                Console.WriteLine("\tDeviceID  -  " + obj["DeviceID"]);
                Console.WriteLine("\tManufacturer  -  " + obj["Manufacturer"]);
                Console.WriteLine("\tCurrentClockSpeed  -  " + obj["CurrentClockSpeed"]);
                Console.WriteLine("\tCaption  -  " + obj["Caption"]);
                Console.WriteLine("\tNumberOfCores  -  " + obj["NumberOfCores"]);
                Console.WriteLine("\tNumberOfEnabledCore  -  " + obj["NumberOfEnabledCore"]);
                Console.WriteLine("\tNumberOfLogicalProcessors  -  " + obj["NumberOfLogicalProcessors"]);
                Console.WriteLine("\tArchitecture  -  " + obj["Architecture"]);
                Console.WriteLine("\tFamily  -  " + obj["Family"]);
                Console.WriteLine("\tProcessorType  -  " + obj["ProcessorType"]);
                Console.WriteLine("\tCharacteristics  -  " + obj["Characteristics"]);
                Console.WriteLine("\tAddressWidth  -  " + obj["AddressWidth"]);
            }
            this.pausa();
        }
    }
}
