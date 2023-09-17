using System.IO;
using System.Text; // Para encoding

namespace Registro {
    internal class Persona {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? Fnacto { get; set; }
        public Documento? documento { get; set; }

        public Persona() {}
        public Persona(string nombre, string apellido, 
                    DateTime fnacto, Documento documento) {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Fnacto = fnacto;
            this.documento = documento;
        }

        public override string ToString() {
            return @$"Nombre: {Nombre}, Apellido: {Apellido},F.Nacto: {Fnacto?.ToString("dd/MM/yyyy")??"N/D"},  Documento: {documento}";
        }

        public string xml() {
            return @$"
<persona><nombre>{Nombre}</nombre><apellido>{Apellido}</apellido>
<fnacto>{Fnacto?.ToString("dd/MM/yyyy")??"N/D"}</fnacto>{documento?.xml()??"N/D"}</persona>
";
        }
        //SI documento es null, no llama a la funcion puesta.

        private Boolean verificarCarpeta(string carpeta) {
            // Verificar carpeta
            if (!System.IO.Directory.Exists(carpeta))
            {
                try {
                    System.IO.Directory.CreateDirectory(carpeta);
                }
                catch(Exception e) {
                    Console.WriteLine("Error creando carpeta {carpeta}");
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            return true;
        }
        private Boolean crearArchivo(string archivo) {
            try {
                StreamWriter sw = new StreamWriter(archivo);
                sw.WriteLine(this.xml());
                sw.Close();
                return true;
            }
            catch (Exception e) {
                Console.WriteLine("Error guardando archivo {archivo}");
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public void guardar() {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string carpeta = $@"{desktop}/Personas";
            string archivo = $@"{carpeta}/{this.documento?.Tipo}_{this.documento?.Numero}.xml";
            if (verificarCarpeta(carpeta) && crearArchivo(archivo))
                Console.WriteLine($"{archivo} creado Ok");
        }

        public static void listarArchivos() {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string carpeta = $@"{desktop}/Personas";
            try {
                foreach(string s in Directory.GetFiles(carpeta))
                    Console.WriteLine(s);
            }
            catch (Exception e) {
                Console.WriteLine("Error leyendo carpeta {carpeta}");
                Console.WriteLine(e.Message);
            }
        }

        public static void leerArchivo(string tipodocumento, string numerodocumento) {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string carpeta = $@"{desktop}/Personas";
            string archivo = $@"{carpeta}/{tipodocumento}_{numerodocumento}.xml";
            try {
                string text = File.ReadAllText(archivo, Encoding.UTF8);
                Console.WriteLine(text);
            }
            catch (Exception e) {
                Console.WriteLine("Error leyendo archivo {carpeta}");
                Console.WriteLine(e.Message);
            }

        }


    }
}