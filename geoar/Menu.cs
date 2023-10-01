using System.Runtime.InteropServices;

namespace GeoAr {
    class Menu {
        string margen = "    ";
        string separador = "----";
        List<Provincia> provincias;
        int opcion;

        public int Opcion { get { return this.opcion; }}

        DateTime fecha;
        public Menu(List<Provincia> provincias) {
            this.provincias = provincias;
            mostrar();
        }

        private void encabezado() {
            fecha = DateTime.Now;
            Console.WriteLine($"{margen}{new String('-',72)}");
            Console.WriteLine($"{margen}{separador} Fecha: {fecha.ToString()}");
            Console.WriteLine($"{margen}{separador} Provincias");
            Console.WriteLine($"{margen}{new String('-',72)}");
        }

        private void mostrar() {
            Console.Clear();
            encabezado();
            foreach(Provincia p in provincias.OrderBy(x => x.Nombre)) {
                Console.WriteLine($"{margen}{margen} {p.Id.ToString().PadLeft(2)}: {p.Nombre}");
            }
        }

        public int seleccionar() {
            while(true) {
                Console.Write($"\n\n{margen}{separador} Ingrese su opcion (0 para terminar): ");
                if (int.TryParse(Console.ReadLine(), out opcion)) {
                    if (opcion == 0) {
                        return opcion;
                    }
                    if (provincias.Exists(x => x.Id == opcion)) {
                        return opcion;
                    }
                    else {
                        Console.Write($"{margen}{separador} Opcion Invalida: {opcion}, pulse Enter ");
                        Console.ReadLine();
                        mostrar();
                        continue;
                    }
                }
            }
        }
    }
}