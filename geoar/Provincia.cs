using System.Text;
using System.Text.Json;

namespace GeoAr {
    class Provincia {
        string categoria;
        double latitud;
        double longitud;
        string fuente;
        int id;
        string iso_id;
        string iso_nombre;
        string nombre;
        string nombre_completo;

        public string Nombre { get { return this.nombre; } }
        public int Id { get { return this.id; } }
        public double Latitud { get { return this.latitud; } }
        public double Longitud { get { return this.longitud; } }
        public Provincia(string data) {
            string[] datos = data.Replace("\"","").Split(',');
            this.categoria = datos[0].Trim();
            this.latitud = Double.Parse(datos[1].Trim());
            this.longitud = Double.Parse(datos[2].Trim());
            this.fuente = datos[3].Trim();
            this.id = int.Parse(datos[4].Trim());
            this.iso_id = datos[5].Trim();
            this.iso_nombre = datos[6].Trim();
            this.nombre = datos[7].Trim();
            this.nombre_completo = datos[8].Trim();
        }

        public override string ToString() {
            return $"{this.nombre} ({this.latitud},{this.longitud})";
        }
        public string xml() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<provincia>");
            sb.Append($"<categoria>{this.categoria}</categoria>");
            sb.Append($"<latitud>{this.latitud}</latitud>");
            sb.Append($"<longitud>{this.longitud}</longitud>");
            sb.Append($"<fuente>{this.fuente}</fuente>");
            sb.Append($"<id>{this.id}</id>");
            sb.Append($"<iso_id>{this.iso_id}</iso_id>");
            sb.Append($"<iso_nombre>{this.iso_nombre}</iso_nombre>");
            sb.Append($"<nombre>{this.nombre}</nombre>");
            sb.Append($"<nombre_completo>{this.nombre_completo}</nombre_completo>");
            sb.Append("</provincia>");
            return sb.ToString();
        }

        public string json() {
            return JsonSerializer.Serialize(this);
        }
        public static List<Provincia> cargar_datos() {
            string archivo =  Path.Combine(Config.dir_datos, Config.url_provincias.Split('/').Last());

            List<Provincia> provincias = new List<Provincia>();
            foreach(string s in Archivo.cargar(archivo).Skip(1)) {
                provincias.Add(new Provincia(s));
            }
            return provincias;
        }
    }
}