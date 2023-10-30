using System.IO;

namespace LibDomicilio {
    public class Provincia {
        public int id;
        public string nombre;
        private string error = "";
        public string Error { get { return error; } }
        static string archivo = "/home/juan/dev/Labo2_2023/LibDomicilio/data/provincias.csv";
        public static List<Provincia> lista = new List<Provincia>();
        public Provincia(int id, string nombre) {
            this.id = id;
            this.nombre = nombre;
        }
        public override string ToString()
        {
            return $"Provincia: {this.id} {this.nombre}";
        }
        public static void cargar() {
            try {
                string[] lineas = File.ReadAllLines(archivo);
                foreach( string linea in lineas) {
                    string[] campos = linea.Split(',');
                    int campo_id = Int32.Parse(campos[0]);
                    string campo_nombre = campos[1];
                    Provincia p = new Provincia(campo_id, campo_nombre);
                    lista.Add(p);
                }
            }
            catch (Exception e) {
                string error =  $"Error leyendo provincias: {e.Message}";
            }
        }
    }
}