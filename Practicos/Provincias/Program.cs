using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Provincias {
    class Program {
        public static void Main(string[] args) {
            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string archivo = Path.Combine(escritorio,"provincias.csv");
            string[] filas = {};
            List<Provincia> provincias = new List<Provincia>();

            try {
                filas = File.ReadAllLines(archivo);
            } catch (IOException ioe) {
                Console.WriteLine($"Error abriendo archivo {archivo}");
                Console.WriteLine(ioe.Message);
                Environment.Exit(1);
            }

            int contador = 0;
            foreach(string s in filas) {
                if (contador == 0) {
                    contador = 1;
                    continue;
                }
                provincias.Add(new Provincia(s));
            }

            //generarXml(escritorio, provincias);
            //generarJson(escritorio, provincias);

            foreach (Provincia p in provincias) {

                string output = JsonConvert.SerializeObject(p);
                Console.WriteLine($"{p} {output}");
            }
            Environment.Exit(0);
        }
        static void generarXml(string escritorio, List<Provincia> provincias) {
            string archivox = Path.Combine(escritorio, "Provincias.xml");
            try {
                if (File.Exists(archivox)) {
                    File.Delete(archivox);
                }
                StreamWriter sw = new StreamWriter(archivox);
                StringBuilder sb = new StringBuilder();
                sb.Append("<provincias>");
                foreach(Provincia p in provincias)
                    sb.Append(p.xml());
                sb.Append("</provincias>");
                sw.Write(sb.ToString());
                sw.Close();
            } catch (IOException ioe) {
                Console.WriteLine($"Error procesando archivo {archivox}");
                Console.WriteLine(ioe.Message);
            }
        }    
        static void generarJson(string escritorio, List<Provincia> provincias) {
            string archivoj = Path.Combine(escritorio, "Provincias.json");
            try {
                if (File.Exists(archivoj)) {
                    File.Delete(archivoj);
                }
                StreamWriter sw = new StreamWriter(archivoj);
                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                int contador = 0;
                foreach(Provincia p in provincias) {
                    if (contador == 0) {
                        contador = 1;
                        sb.Append(p.json());
                        continue;
                    }
                    sb.Append($",{p.json()}");
                }
                sb.Append("]");
                sw.Write(sb.ToString());
                sw.Close();
            } catch (IOException ioe) {
                Console.WriteLine($"Error procesando archivo {archivoj}");
                Console.WriteLine(ioe.Message);
            }
        }    
    }
}