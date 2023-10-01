using System.Net;
using System.IO;
namespace GeoAr {
    class Archivo {
        public static void descargar(string url_origen) {
            if (verificar_destino(Config.dir_datos)) {
                try {
                    string archivo = Path.Combine(Config.dir_datos, url_origen.Split('/').Last());
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(url_origen, archivo);                
                }
                catch (Exception e) {
                    Console.WriteLine($"Error bajando archivo {url_origen.Split('/').Last()}");
                    Console.WriteLine(e.Message);
                }
            }
            else {
                return;
            }
        }
        private static Boolean verificar_destino(string destino) {
            if (!Directory.Exists(destino)) {
                try {
                    Directory.CreateDirectory(destino);
                    Console.WriteLine($"OK. Carpeta {destino} creada");
                } catch(IOException ioe) {
                    Console.WriteLine($"Error creado la carpeta {destino}");
                    Console.WriteLine(ioe.Message);
                    return false;
                }
            } 
            else {
                Console.WriteLine($"OK. La carpeta {destino} ya existe");
            }
            return true;
        }

        public static string[] cargar(string archivo) {
            string[] datos = {};
            try {
                datos = File.ReadAllLines(archivo);
                Console.WriteLine($"{archivo} cargado OK");
            }
            catch(Exception e) {
                Console.WriteLine($"Error cargando archivo {archivo}");
                Console.WriteLine(e.Message);
            }
            return datos;
        }

    }
}