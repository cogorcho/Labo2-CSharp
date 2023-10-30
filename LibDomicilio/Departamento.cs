using System.IO;

namespace LibDomicilio {
    public class Departamento {
        public int id;
        public int provinciaid;
        public string nombre;
        private string error = "";
        public string Error { get { return error; } }
        static string archivo = "/home/juan/dev/Labo2_2023/LibDomicilio/data/departamentos.csv";
        public static List<Departamento> lista = new List<Departamento>();
        public Departamento(int provinciaid, int id, string nombre) {
            this.provinciaid = provinciaid;
            this.id = id;
            this.nombre = nombre;
        }
        public override string ToString()
        {
            return $"Departamento: {this.id} {this.nombre}";
        }
        public static void cargar() {
            try {
                string[] lineas = File.ReadAllLines(archivo);
                foreach(string linea in lineas) {
                    string[] campos = linea.Split(',');
                    int pcia_id = Int32.Parse(campos[0]);
                    int campo_id = Int32.Parse(campos[1]);
                    string campo_nombre = campos[2];
                    Departamento d = new Departamento(pcia_id, campo_id, campo_nombre);
                    lista.Add(d);
                }
            }
            catch (Exception e) {
                string error =  $"Error leyendo departamentos: {e.Message}";
            }
        }
    }
}