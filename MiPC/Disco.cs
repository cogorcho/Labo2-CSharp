using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiPC
{
    class Disco
    {
        String nombre;
        DriveType tipo;
        String etiqueta;
        float espacioTotal;
        float espacioLibre;
        DirectoryInfo raiz;

        public Disco() { }
        public Disco(DriveInfo disco)
        {
            this.nombre = disco.Name;
            this.tipo = disco.DriveType;
            this.espacioTotal = disco.TotalSize / 1024 / 1024 / 1024;
            this.espacioLibre = disco.TotalFreeSpace / 1024 / 1024 / 1024;
            this.raiz = disco.RootDirectory;
        }

        public String Nombre
        {
            get { return this.nombre; }
        }
        public String Tipo
        {
            get { return this.tipo.ToString(); }
        }

        public override String ToString()
        {
            return String.Format("\tNombre: {0}\n\tTipo: {1}\n\tTamaño: {2} GB\n\tLibre: {3} GB\n\tRaiz: {4}",
                this.nombre, this.tipo.ToString(), this.espacioTotal, this.espacioLibre, this.raiz.Name);
        }

        public String[] directorios(String raiz)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(raiz);
            return Directory.GetDirectories(raiz);
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
            Console.WriteLine("\t#\tDiscos");
            Console.WriteLine("\t# ----------------------------------");
        }

        public void mostrar()
        {
            int opc = 1;
            DriveInfo[] discos = DriveInfo.GetDrives();
            this.encabezado();
            foreach (var drive in discos)
            {
                Disco d = new Disco(drive);
                Console.WriteLine(String.Format("\t{0}: {1} -> Tipo: {2}, {3} GB Total, {4} GB Libres", 
                    opc, d.Nombre, d.Tipo, d.espacioTotal, d.espacioLibre));
                opc++;
            }
            this.pausa();
        }

    }
}
