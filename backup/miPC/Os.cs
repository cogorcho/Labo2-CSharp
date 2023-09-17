using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace MiPC
{
    class Os
    {
        public Os() { }

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
            Console.WriteLine("\t#\tSistema operativo");
            Console.WriteLine("\t# ----------------------------------");
        }

        public void mostrar()
        {
            ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            this.encabezado();
            foreach (ManagementObject obj in myOperativeSystemObject.Get())
            {
                Console.WriteLine("\tCaption  -  " + obj["Caption"]);
                Console.WriteLine("\tWindowsDirectory  -  " + obj["WindowsDirectory"]);
                Console.WriteLine("\tProductType  -  " + obj["ProductType"]);
                Console.WriteLine("\tSerialNumber  -  " + obj["SerialNumber"]);
                Console.WriteLine("\tSystemDirectory  -  " + obj["SystemDirectory"]);
                Console.WriteLine("\tCountryCode  -  " + obj["CountryCode"]);
                Console.WriteLine("\tCurrentTimeZone  -  " + obj["CurrentTimeZone"]);
                Console.WriteLine("\tEncryptionLevel  -  " + obj["EncryptionLevel"]);
                Console.WriteLine("\tOSType  -  " + obj["OSType"]);
                Console.WriteLine("\tVersion  -  " + obj["Version"]);
            }

            this.pausa();
        }
    }
}
