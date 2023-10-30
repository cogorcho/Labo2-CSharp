using System.IO;

namespace LibDomicilio {
    public class Localidad {
        int provinciaid;
        public int departamentoid;
        public long id;
        public string nombre;
        private string error = "";
        public string Error { get { return error; } }
        static string archivo = "/home/juan/dev/Labo2_2023/LibDomicilio/data/localidades.csv";
        public static List<Localidad> lista = new List<Localidad>();
        public Localidad(int provinciaid, int departamentoid, long id, string nombre) {
            this.provinciaid = provinciaid;
            this.departamentoid = departamentoid;
            this.id = id;
            this.nombre = nombre;
        }
        public override string ToString()
        {
            return $"Localidad: {this.id} {this.nombre}";
        }
        public static void cargar() {
            try {
                string[] lineas = File.ReadAllLines(archivo);
                foreach( string linea in lineas) {
                    string[] campos = linea.Split(',');
                    int pcia_id = Int32.Parse(campos[0]);
                    int depto_id = Int32.Parse(campos[1]);
                    long local_id = long.Parse(campos[2]);
                    string campo_nombre = campos[3];
                    Localidad l = new Localidad(pcia_id, depto_id, local_id, campo_nombre);
                    lista.Add(l);
                }
            }
            catch (Exception e) {
                string error =  $"Error leyendo Localidades: {e.Message}";
                Console.WriteLine($"{error}");
            }
        }
    }
}