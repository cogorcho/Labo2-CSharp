using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace MiPC
{
    class Audio
    {
        public Audio() { }
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
            Console.WriteLine("\t#\tAudio");
            Console.WriteLine("\t# ----------------------------------");
        }

        public void mostrar()
        {
            this.encabezado();
            ManagementObjectSearcher myAudioObject = new ManagementObjectSearcher("select * from Win32_SoundDevice");

            foreach (ManagementObject obj in myAudioObject.Get())
            {
                Console.WriteLine("\tName  -  " + obj["Name"]);
                Console.WriteLine("\tProductName  -  " + obj["ProductName"]);
                Console.WriteLine("\tAvailability  -  " + obj["Availability"]);
                Console.WriteLine("\tDeviceID  -  " + obj["DeviceID"]);
                Console.WriteLine("\tPowerManagementSupported  -  " + obj["PowerManagementSupported"]);
                Console.WriteLine("\tStatus  -  " + obj["Status"]);
                Console.WriteLine("\tStatusInfo  -  " + obj["StatusInfo"]);
                //Console.WriteLine(String.Empty.PadLeft(obj["ProductName"].ToString().Length, '='));
                Console.WriteLine("\t ----------------------------------");
            }
            pausa();
        }
    }
}
