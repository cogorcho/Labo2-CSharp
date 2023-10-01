using System.IO;

namespace GeoAr {
    class Program {
        static List<Provincia> provincias = Provincia.cargar_datos();
        static List<Departamento> departamentos = Departamento.cargar_datos();
        static List<Localidad> localidades = Localidad.cargar_datos();
        
        public static void Main(string[] args) {
            descargar_archivos();
            menu();
            foreach(Provincia p in provincias)
                Console.WriteLine(p.json());
        }
        private static void descargar_archivos() {
            Archivo.descargar(Config.url_provincias);
            Archivo.descargar(Config.url_departamentos);
            Archivo.descargar(Config.url_localidades);
        }

        private static void menu() {
            while(true) {
                Menu menu = new Menu(provincias);
                int pciaid = menu.seleccionar();
                if (pciaid == 0) {
                    Console.Clear();
                    break;
                }
                Console.Clear();
                Console.WriteLine(provincias.Find(x => x.Id == pciaid));
                List<Departamento> deptosxpcia = departamentos.FindAll(x => x.Provincia_id == pciaid);
                foreach(Departamento d in deptosxpcia.OrderBy(x => x.Nombre)) {
                    Console.WriteLine($"    {d}");
                    foreach(Localidad l in localidades.FindAll(x => x.Departamento_id == d.Id).OrderBy(x => x.Nombre))
                        Console.WriteLine($"        {l}");
                }
                Console.Write("\n\n    Pulse una tecla para continuar");
                Console.ReadKey();
            }
        }
    }
}