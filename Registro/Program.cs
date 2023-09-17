using System.Globalization;

namespace Registro {
    internal class Program {
        public static void Main(string[] args) {
            Util u = new Util();
            Persona.listarArchivos();
            Persona.leerArchivo(u.getString("Tipo Documento"), u.getString("Numero de documento"));
        }

        private static void Messi() {
            Documento d = new Documento();
            d.Tipo = "DNI";
            d.Numero = "20200200";
            
            Persona lionel = new Persona();
            lionel.Nombre = "Lionel";
            lionel.Apellido = "Messi";
            lionel.Fnacto = DateTime.ParseExact("20/06/1987", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            lionel.documento = d;
            Console.WriteLine(lionel);
            Console.WriteLine(lionel.xml());
        }

        private static void Dibu() {
            Persona dibu = new Persona(
                    "Dibu",
                    "Martinez",
                    DateTime.ParseExact("27/04/1994", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    new Documento("Pasaporte Argentino","34233322"));
            Console.WriteLine(dibu); 
            Console.WriteLine(dibu.xml());           
        }

        private static void cargaManual() {
            Util u = new Util();
            Documento d2 = new Documento(u.getString("Tipo Documento"), 
                    u.getString("Numero de Documento"));
            Persona x = new Persona(
                u.getString("Nombre"),
                u.getString("Apellido"),
                u.getFecha("Fecha de Nacimiento"),
                d2
            );
            Console.WriteLine(x);
            Console.WriteLine(x.xml());
            x.guardar();
        }
    }
}


