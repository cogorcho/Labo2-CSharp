using LibDomicilio;

namespace PruebaLib {

    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Cargando Provincias");
            Provincia.cargar();
            Console.WriteLine($"Cargadas {Provincia.lista.Count} Provincias");

            Console.WriteLine("Cargando Departamentos");
            Departamento.cargar();
            Console.WriteLine($"Cargados {Departamento.lista.Count} Departamentos");

            Console.WriteLine("Cargando Localidades");
            Localidad.cargar();
            Console.WriteLine($"Cargadas {Localidad.lista.Count} Localidades");

            // Ejemplo de Localidades x Departamento x Provincia 
            Console.WriteLine(Provincia.lista.Find(x => x.id == 78));
            var deptos = Departamento.lista.FindAll(x => x.provinciaid == 78);
            foreach(Departamento d in deptos) {
                Console.WriteLine(d);
                foreach(Localidad l in Localidad.lista.FindAll(x => x.departamentoid == d.id))
                    Console.WriteLine($"    {l}");
            }
        }
    }
}
